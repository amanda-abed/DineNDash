using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;
using DineNDash.Services;
using DineNDash.Models;
using Prism.Services;

namespace DineNDash.ViewModels
{
    public class CartPageViewModel : BindableBase, INavigationAware
    {
        INavigationService nav_service;
        IPageDialogService page_service;
        IRepository _repo;

        public DelegateCommand CheckoutCommand { get; set; }
        public DelegateCommand PullToRefreshCommand { get; set; }
        public DelegateCommand<OrderItem> DeleteCommand { get; set; }

        private ObservableCollection<OrderItem> food_item;
        public ObservableCollection<OrderItem> FoodItem
        {
            get { return food_item; }
            set { SetProperty(ref food_item, value); }
        }

        private string total_items;
        public string TotalItems
        {
            get { return total_items; }
            set { SetProperty(ref total_items, value); }
        }

        private bool _showIsBusySpinner;
        public bool ShowIsBusySpinner
        {
            get { return _showIsBusySpinner; }
            set { SetProperty(ref _showIsBusySpinner, value); }
        }

        public CartPageViewModel(INavigationService navigationService, IRepository repository, IPageDialogService pageDialogService)
        {
            nav_service = navigationService;
            page_service = pageDialogService;
            _repo = repository;

            CheckoutCommand = new DelegateCommand(GoToPaymentsPage);
            PullToRefreshCommand = new DelegateCommand(OnPullToRefresh);
            DeleteCommand = new DelegateCommand<OrderItem>(OnDeleteTapped);
            RefreshItemList();
        }

        private async void OnPullToRefresh()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnPullToRefresh)}");

            await RefreshItemList();
        }

        private async Task RefreshItemList()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(RefreshItemList)}");

            if (FoodItem == null)
            {
                ShowIsBusySpinner = true;
                FoodItem = new ObservableCollection<OrderItem>();
                ShowIsBusySpinner = false;
            }
            else
            {
                ShowIsBusySpinner = true;
                var itemsList = await _repo.GetItem();
                if (itemsList != null)
                {
                    FoodItem = new ObservableCollection<OrderItem>(itemsList);
                }
                ShowIsBusySpinner = false;
            }
        }

        private void OnDeleteTapped(OrderItem itemToDelete)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnDeleteTapped)}:  {itemToDelete}");
            _repo.RemoveItem(itemToDelete);
            FoodItem.Remove(itemToDelete);
        }

        private async void GoToPaymentsPage()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(GoToPaymentsPage)}");

            if (FoodItem.Count == 0)
            {
                await page_service.DisplayAlertAsync("Error", "Your cart is empty", "Dismiss");
                return;
            }
            else
            {
                await nav_service.NavigateAsync("PaymentPage", null);
            }
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatedFrom)}");
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatedTo)}");
        }

        public async void OnNavigatingTo(INavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatingTo)}");

            if (parameters != null && parameters.ContainsKey("ItemAdded"))
            {
                if (FoodItem == null)
                {
                    FoodItem = new ObservableCollection<OrderItem>();
                }
                var itemToAdd = (OrderItem)parameters["ItemAdded"];
                FoodItem.Add(itemToAdd);

                TotalItems = itemToAdd.ToString();
            }
            await RefreshItemList();
        }
    }
}

