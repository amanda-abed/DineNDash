using System;
using System.Diagnostics;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace DineNDash.ViewModels
{
    public class CashPageViewModel : BindableBase, INavigationAware
    {
        INavigationService nav_service;
        IPageDialogService _pageDialogService;
        public DelegateCommand NextPage { get; set; }

        private string secret_code;
        public string SecretCode
        {
            get { return secret_code; }
            set { SetProperty(ref secret_code, value); }
        }

        public CashPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(CashPageViewModel)}:  ctor");

            nav_service = navigationService;
            _pageDialogService = pageDialogService;

            NextPage = new DelegateCommand(OnNextPage);
        }

        private async void OnNextPage()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNextPage)}");

            if(string.IsNullOrEmpty(secret_code)){
                await _pageDialogService.DisplayAlertAsync("Error", "A server must enter valid code", "Dismiss");
                return;
            }

            if (secret_code == "!8&v"){
                await nav_service.NavigateAsync("ConfirmationPage", null);
            }
            else if(secret_code == "" || secret_code != "!8&v"){
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

