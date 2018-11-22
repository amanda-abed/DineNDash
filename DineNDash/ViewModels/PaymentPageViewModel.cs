using System;
using System.Collections.Generic;
using System.Diagnostics;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;
using DineNDash.Views;
using Prism.Services;

namespace DineNDash.ViewModels
{
    public class PaymentPageViewModel : BindableBase, INavigationAware
    {
        INavigationService _navigationService;
        IPageDialogService displayMessage;

        public DelegateCommand ContinueToPayment { get; set; }

        public PaymentPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            displayMessage = pageDialogService;

            _methods = new List<string>()
            {
                "Cash",
                "Credit Card"
            };

            ContinueToPayment = new DelegateCommand(GoToPayment);
        }

        private async void GoToPayment()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(GoToPayment)}");

            if(string.IsNullOrEmpty(selectedMethod)){
                await displayMessage.DisplayAlertAsync("Error", "You must choose a payment method", "Dismiss");
                return;
            }

            if (selectedMethod == "Credit Card")
            {
                await _navigationService.NavigateAsync("CreditInfoPage", null);
            }
            else{
                await _navigationService.NavigateAsync("CashPage", null);
            }
        }

        List<string> _methods;
        public List<string> Methods
        {
            get { return _methods; }
            set { SetProperty(ref _methods, value); }
        }

        private string selectedMethod;
        public string SelectedMethod
        {
            get { return selectedMethod; }
            set { SetProperty(ref selectedMethod, value); }
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

