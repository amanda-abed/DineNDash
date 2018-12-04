using System;
using System.Diagnostics;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;
using DineNDash.Models;
using DineNDash.Services;
using System.Threading.Tasks;
using Prism.Services;

namespace DineNDash.ViewModels
{
    public class TabSideAndDrinksPageViewModel : BindableBase, INavigationAware
    {
        INavigationService nav_service;
        IPageDialogService page_service;
        IRepository _repo;

        public DelegateCommand TapToOrder { get; set; }
        public DelegateCommand TapToOrder1 { get; set; }
        public DelegateCommand TapToOrder2 { get; set; }
        public DelegateCommand TapToOrder3 { get; set; }

        private string place_order;
        private string place_order1;
        private string place_order2;
        private string place_order3;
        public string PlaceOrder
        {
            get { return place_order; }
            set { SetProperty(ref place_order, value); }
        }
        public string PlaceOrder1
        {
            get { return place_order1; }
            set { SetProperty(ref place_order1, value); }
        }
        public string PlaceOrder2
        {
            get { return place_order2; }
            set { SetProperty(ref place_order2, value); }
        }
        public string PlaceOrder3
        {
            get { return place_order3; }
            set { SetProperty(ref place_order3, value); }
        }
        public TabSideAndDrinksPageViewModel(INavigationService navigationService, IRepository repository, IPageDialogService pageDialogService)
        {
            nav_service = navigationService;
            page_service = pageDialogService;
            _repo = repository;

            PlaceOrder = "Cookies \n $0.79";
            PlaceOrder1 = "Chips \n $1.29";
            PlaceOrder2 = "Coca Cola Fountain Sodas \n $1.99";
            PlaceOrder3 = "Milk \n $1.59";

            TapToOrder = new DelegateCommand(AddToCart);
            TapToOrder1 = new DelegateCommand(AddToCart1);
            TapToOrder2 = new DelegateCommand(AddToCart2);
            TapToOrder3 = new DelegateCommand(AddToCart3);
        }

        private async void AddToCart()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(AddToCart)}");

            bool userResponse = await page_service.DisplayAlertAsync("Add Item?", "Are you sure you want to add item to cart?", "Ok", "Cancel");
            if (userResponse == false)
                return;
            else
            {
                OrderItem newItem = new OrderItem
                {
                    Item = this.PlaceOrder
                };

                await _repo.AddItem(newItem);
                var navParams = new NavigationParameters();
                navParams.Add("ItemAdded", newItem);
                await Task.Delay(1);

                Restaurant2SideItem newItema = new Restaurant2SideItem
                {
                    Item = this.PlaceOrder
                };

                await _repo.AddItem(newItema);
                var navParams1 = new NavigationParameters();
                navParams1.Add("ItemAdded", newItema);
                await Task.Delay(1);
            }

        }
        private async void AddToCart1()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(AddToCart1)}");

            bool userResponse = await page_service.DisplayAlertAsync("Add Item?", "Are you sure you want to add item to cart?", "Ok", "Cancel");
            if (userResponse == false)
                return;
            else
            {
                OrderItem newItem1 = new OrderItem
                {
                    Item = this.PlaceOrder1
                };

                await _repo.AddItem(newItem1);
                var navParams = new NavigationParameters();
                navParams.Add("ItemAdded", newItem1);
                await Task.Delay(1);

                Restaurant2SideItem newItem1a = new Restaurant2SideItem
                {
                    Item = this.PlaceOrder1
                };

                await _repo.AddItem(newItem1a);
                var navParams1 = new NavigationParameters();
                navParams1.Add("ItemAdded", newItem1a);
                await Task.Delay(1);
            }

        }
        private async void AddToCart2()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(AddToCart2)}");

            bool userResponse = await page_service.DisplayAlertAsync("Add Item?", "Are you sure you want to add item to cart?", "Ok", "Cancel");
            if (userResponse == false)
                return;
            else
            {
                OrderItem newItem2 = new OrderItem
                {
                    Item = this.PlaceOrder2
                };

                await _repo.AddItem(newItem2);
                var navParams = new NavigationParameters();
                navParams.Add("ItemAdded", newItem2);
                await Task.Delay(1);

                Restaurant2SideItem newItem2a = new Restaurant2SideItem
                {
                    Item = this.PlaceOrder2
                };

                await _repo.AddItem(newItem2a);
                var navParams1 = new NavigationParameters();
                navParams1.Add("ItemAdded", newItem2a);
                await Task.Delay(1);
            }

        }
        private async void AddToCart3()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(AddToCart3)}");

            bool userResponse = await page_service.DisplayAlertAsync("Add Item?", "Are you sure you want to add item to cart?", "Ok", "Cancel");
            if (userResponse == false)
                return;
            else
            {
                OrderItem newItem3 = new OrderItem
                {
                    Item = this.PlaceOrder3
                };

                await _repo.AddItem(newItem3);
                var navParams = new NavigationParameters();
                navParams.Add("ItemAdded", newItem3);
                await Task.Delay(1);

                Restaurant2SideItem newItem3a = new Restaurant2SideItem
                {
                    Item = this.PlaceOrder3
                };

                await _repo.AddItem(newItem3a);
                var navParams1 = new NavigationParameters();
                navParams1.Add("ItemAdded", newItem3a);
                await Task.Delay(1);
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

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatingTo)}");
        }

    }
}


