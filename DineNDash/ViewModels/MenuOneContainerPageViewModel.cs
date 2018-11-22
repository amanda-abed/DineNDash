using System;
using System.Diagnostics;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace DineNDash.ViewModels
{
    public class MenuOneContainerPageViewModel : BindableBase, INavigationAware
    {
        INavigationService nav_service;

        public DelegateCommand GoToCart { get; set; }

        public MenuOneContainerPageViewModel(INavigationService navigationService)
        {
            nav_service = navigationService;

            GoToCart = new DelegateCommand(OnToCart);
        }

        private async void OnToCart()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnToCart)}");

            await nav_service.NavigateAsync("CartPage", null);
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

