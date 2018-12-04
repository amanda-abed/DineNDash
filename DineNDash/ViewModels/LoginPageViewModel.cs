using System;
using System.Diagnostics;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace DineNDash.ViewModels
{
    public class LoginPageViewModel : BindableBase, INavigationAware
    {
        INavigationService nav_service;
        IPageDialogService _pageDialogService;

        public DelegateCommand loginButton { get; set; }

        private string rest_id;
        public string restID
        {
            get { return rest_id; }
            set { SetProperty(ref rest_id, value); }
        }

        private string rest_password;
        public string restPassword
        {
            get { return rest_password; }
            set { SetProperty(ref rest_password, value); }
        }

        public LoginPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            nav_service = navigationService;
            _pageDialogService = pageDialogService;

            loginButton = new DelegateCommand(GoToRestCalls);
        }

        private async void GoToRestCalls()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(GoToRestCalls)}");

            if (rest_password == "!8&v" && rest_id == "RestaurantInNOut")
            {
                await nav_service.NavigateAsync("CallsPage", null);
            }

            if (rest_password == "!8&v" && rest_id == "RestaurantSubway")
            {
                await nav_service.NavigateAsync("CallsSubPage", null);
            }

            if (string.IsNullOrEmpty(rest_id) || string.IsNullOrEmpty(rest_password))
            {
                await _pageDialogService.DisplayAlertAsync("Error", "All fields must be filled out", "Dismiss");
                return;
            }
            else if (rest_id != "RestaurantInNOut" && rest_password != "!8&v")
            {
                await _pageDialogService.DisplayAlertAsync("Error", "Fields entered are invalid. Please try again", "Dismiss");
                return;
            }
            else if (rest_id != "RestaurantSubway" && rest_password != "!8&v")
            {
                await _pageDialogService.DisplayAlertAsync("Error", "Fields entered are invalid. Please try again", "Dismiss");
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

