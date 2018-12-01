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
    public class TabSandwichesPageViewModel : BindableBase, INavigationAware
    {
        INavigationService nav_service;
        IPageDialogService page_service;
        IRepository _repo;

        public DelegateCommand TapToOrder { get; set; }
        public DelegateCommand TapToOrder1 { get; set; }
        public DelegateCommand TapToOrder2 { get; set; }
        public DelegateCommand TapToOrder3 { get; set; }
        public DelegateCommand TapToOrder4 { get; set; }

        private string place_order;
        private string place_order1;
        private string place_order2;
        private string place_order3;
        private string place_order4;
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
        public string PlaceOrder4
        {
            get { return place_order4; }
            set { SetProperty(ref place_order4, value); }
        }
        public TabSandwichesPageViewModel(INavigationService navigationService, IRepository repository, IPageDialogService pageDialogService)
        {
            nav_service = navigationService;
            page_service = pageDialogService;
            _repo = repository;

            PlaceOrder = "Turkey Breast \n Footlong: $6.75 \n 6-inch: $4.25";
            PlaceOrder1 = "Subway Club \n Footlong: $7.75 \n 6-inch: $4.75";
            PlaceOrder2 = "Oven Roasted Chicken \n Footlong: $6.75 \n 6-inch: $4.25";
            PlaceOrder3 = "Tuna \n Footlong: $6.75 \n 6-inch: $4.25";
            PlaceOrder4 = "Veggie Delite \n Footlong: $5.50 \n 6-inch: $3.75";

            TapToOrder = new DelegateCommand(AddToCart);
            TapToOrder1 = new DelegateCommand(AddToCart1);
            TapToOrder2 = new DelegateCommand(AddToCart2);
            TapToOrder3 = new DelegateCommand(AddToCart3);
            TapToOrder4 = new DelegateCommand(AddToCart4);
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
            }

        }
        private async void AddToCart4()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(AddToCart4)}");

            bool userResponse = await page_service.DisplayAlertAsync("Add Item?", "Are you sure you want to add item to cart?", "Ok", "Cancel");
            if (userResponse == false)
                return;
            else
            {
                OrderItem newItem4 = new OrderItem
                {
                    Item = this.PlaceOrder4
                };

                await _repo.AddItem(newItem4);
                var navParams = new NavigationParameters();
                navParams.Add("ItemAdded", newItem4);
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

