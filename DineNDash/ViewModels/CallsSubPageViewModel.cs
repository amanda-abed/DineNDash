using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using DineNDash.Models;
using DineNDash.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace DineNDash.ViewModels
{
    public class CallsSubPageViewModel : BindableBase, INavigationAware
    {
        INavigationService nav_service;
        IRepository _repo;

        public DelegateCommand logoutCommand { get; set; }
        public DelegateCommand PullToRefreshCommand { get; set; }

        private ObservableCollection<Restaurant2SideItem> restaurant_items;
        public ObservableCollection<Restaurant2SideItem> RestaurantItems
        {
            get { return restaurant_items; }
            set { SetProperty(ref restaurant_items, value); }
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

        public CallsSubPageViewModel(INavigationService navigationService, IRepository repository)
        {
            nav_service = navigationService;
            _repo = repository;

            logoutCommand = new DelegateCommand(GoToHomePage);
            PullToRefreshCommand = new DelegateCommand(OnPullToRefresh);
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

            if (RestaurantItems == null)
            {
                ShowIsBusySpinner = true;
                RestaurantItems = new ObservableCollection<Restaurant2SideItem>();
                ShowIsBusySpinner = false;
            }
            else
            {
                ShowIsBusySpinner = true;
                var itemsList = await _repo.GetItems2();
                if (itemsList != null)
                {
                    RestaurantItems = new ObservableCollection<Restaurant2SideItem>(itemsList);
                }
                ShowIsBusySpinner = false;
            }
        }

        private async void GoToHomePage()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(GoToHomePage)}");

            await nav_service.NavigateAsync("MainPage", null);
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
                if (RestaurantItems == null)
                {
                    RestaurantItems = new ObservableCollection<Restaurant2SideItem>();
                }
                var itemToAdd = (Restaurant2SideItem)parameters["ItemAdded"];
                RestaurantItems.Add(itemToAdd);

                TotalItems = itemToAdd.ToString();
            }
            await RefreshItemList();
        }
    }
}

