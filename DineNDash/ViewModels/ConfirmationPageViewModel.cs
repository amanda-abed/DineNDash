using System;
using System.Diagnostics;
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

        public DelegateCommand RateExperience { get; set; }
        public DelegateCommand AnotherOrder { get; set; }

        public ConfirmationPageViewModel(IPageDialogService pageDialogService, INavigationService navigationService)
        {
            displayMessage = pageDialogService;
            nav_service = navigationService;

            RateExperience = new DelegateCommand(GoToRate);
            AnotherOrder = new DelegateCommand(GoToHomePage);
        }

        private async void GoToHomePage()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(GoToHomePage)}");

            await nav_service.NavigateAsync("MainPage", null);
        }

        private async void GoToRate()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(GoToRate)}");

            bool response = await displayMessage.DisplayAlertAsync("LIKE OUR APP?", "Share your experience with us!", "Rate Now!", "Dismiss");
            if (response == false){
                await nav_service.NavigateAsync("MainPage", null);
            }
            else
            {
                await nav_service.NavigateAsync("RatingsPage", null);
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

