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
    public class TabMealPageViewModel : BindableBase, INavigationAware
    {
        INavigationService nav_service;
        IPageDialogService page_service;
        IRepository _repo;

        public DelegateCommand TapToOrder { get; set; }
        public DelegateCommand TapToOrder1 { get; set; }
        public DelegateCommand TapToOrder2 { get; set; }

        private string place_order;
        private string place_order1;
        private string place_order2;
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

        public TabMealPageViewModel(INavigationService navigationService, IRepository repository, IPageDialogService pageDialogService)
        {
            nav_service = navigationService;
            page_service = pageDialogService;
            _repo = repository;

            PlaceOrder = "Combo #1\nDouble-Double Burger, French Fries, and Medium Drink \n $6.15";
            PlaceOrder1 = "Combo #2\nCheeseburger, French Fries, and Medium Drink \n $5.80";
            PlaceOrder2 = "Combo #3\nHamburger, French Fries, and Medium Drink \n $5.50";

            TapToOrder = new DelegateCommand(AddToCart);
            TapToOrder1 = new DelegateCommand(AddToCart1);
            TapToOrder2 = new DelegateCommand(AddToCart2);
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

                RestaurantSideItem newItem0 = new RestaurantSideItem
                {
                    Item = this.PlaceOrder
                };

                await _repo.AddItem(newItem0);
                var navParams0 = new NavigationParameters();
                navParams0.Add("ItemAdded", newItem0);
                await Task.Delay(1);
            }

            //await nav_service.NavigateAsync("CartPage", navParams);
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

                RestaurantSideItem newItem1a = new RestaurantSideItem
                {
                    Item = this.PlaceOrder1
                };

                await _repo.AddItem(newItem1a);
                var navParams1 = new NavigationParameters();
                navParams1.Add("ItemAdded", newItem1a);
                await Task.Delay(1);
            }

            //await nav_service.NavigateAsync("CartPage", navParams);
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

                RestaurantSideItem newItem2a = new RestaurantSideItem
                {
                    Item = this.PlaceOrder2
                };

                await _repo.AddItem(newItem2a);
                var navParams1 = new NavigationParameters();
                navParams1.Add("ItemAdded", newItem2a);
                await Task.Delay(1);
            }

            //await nav_service.NavigateAsync("CartPage", navParams);
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