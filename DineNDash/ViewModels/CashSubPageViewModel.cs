using System;
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
    public class CashSubPageViewModel : BindableBase, INavigationAware
    {
        INavigationService nav_service;
        IPageDialogService _pageDialogService;
        IRepository _repo;

        public DelegateCommand NextPage { get; set; }

        private string secret_code;
        public string SecretCode
        {
            get { return secret_code; }
            set { SetProperty(ref secret_code, value); }
        }

        private string place_cash;
        public string PlaceCash
        {
            get { return place_cash; }
            set { SetProperty(ref place_cash, value); }
        }

        public CashSubPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IRepository repository)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(CashPageViewModel)}:  ctor");

            _repo = repository;
            nav_service = navigationService;
            _pageDialogService = pageDialogService;

            PlaceCash = "Paid with Cash";

            NextPage = new DelegateCommand(OnNextPage);
        }

        private async void OnNextPage()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNextPage)}");

            if (string.IsNullOrEmpty(secret_code))
            {
                await _pageDialogService.DisplayAlertAsync("Error", "A server must enter valid code", "Dismiss");
                return;
            }

            if (secret_code == "!8&v")
            {
                CrossLocalNotifications.Current.Show("Dine & Dash", "Thank you for your order! Your food is on its way...", 1, DateTime.Now.AddSeconds(2));

                await nav_service.NavigateAsync("ConfirmationSubPage", null);

                Restaurant2SideItem cashPayment2 = new Restaurant2SideItem
                {
                    Item = this.PlaceCash
                };

                await _repo.AddItem(cashPayment2);
                var navParams = new NavigationParameters();
                navParams.Add("ItemAdded", navParams);
                await Task.Delay(1);
            }
            if (secret_code == "" || secret_code != "!8&v")
            {
                await _pageDialogService.DisplayAlertAsync("Error", "Incorrect Code", "Try Again");
                return;
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

