using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using DineNDash.Models;
using DineNDash.Services;
using Plugin.LocalNotifications;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace DineNDash.ViewModels
{
    public class ConfirmationPageViewModel : BindableBase, INavigationAware
    {
        IPageDialogService displayMessage;
        INavigationService nav_service;
        IRepository _repo;

        public DelegateCommand RateExperience { get; set; }
        public DelegateCommand AnotherOrder { get; set; }

        //private ObservableCollection<OrderItem> _item;
        //public ObservableCollection<OrderItem> Item
        //{
        //    get { return _item; }
        //    set { SetProperty(ref _item, value); }
        //}

        private string foodDelivery;
        public string FoodDelivery
        {
            get { return foodDelivery; }
            set { SetProperty(ref foodDelivery, value); }
        }

        public ConfirmationPageViewModel(IPageDialogService pageDialogService, INavigationService navigationService, IRepository repository)
        {
            displayMessage = pageDialogService;
            nav_service = navigationService;
            _repo = repository;

            FoodDelivery = "Food out for delivery";

            RateExperience = new DelegateCommand(GoToRate);
            AnotherOrder = new DelegateCommand(GoToHomePage);
        }

        private async void GoToHomePage()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(GoToHomePage)}");
            await nav_service.NavigateAsync("MainPage", null);
            RestaurantSideItem foodToDeliver = new RestaurantSideItem
            {
                Item = this.FoodDelivery
            };

            await _repo.AddItem(foodToDeliver);
            var navParams = new NavigationParameters();
            navParams.Add("ItemAdded", navParams);
            await Task.Delay(1);
            //_repo.RemoveAllItems(listOfItems);
        }

        private async void GoToRate()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(GoToRate)}");

            bool response = await displayMessage.DisplayAlertAsync("LIKE OUR APP?", "Share your experience with us!", "Rate Now!", "Dismiss");
            if (response == false){
                await nav_service.NavigateAsync("GetStartedPage", null);
                //  _repo.RemoveAllItems(listOfItems);
                RestaurantSideItem foodToDeliver = new RestaurantSideItem
                {
                    Item = this.FoodDelivery
                };

                await _repo.AddItem(foodToDeliver);
                var navParams = new NavigationParameters();
                navParams.Add("ItemAdded", navParams);
                await Task.Delay(1);
            }
            else
            {
                await nav_service.NavigateAsync("RatingsPage", null);
                RestaurantSideItem foodToDeliver = new RestaurantSideItem
                {
                    Item = this.FoodDelivery
                };

                await _repo.AddItem(foodToDeliver);
                var navParams = new NavigationParameters();
                navParams.Add("ItemAdded", navParams);
                await Task.Delay(1);
                //   _repo.RemoveAllItems(listOfItems);
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

