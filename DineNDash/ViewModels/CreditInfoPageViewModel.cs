using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using DineNDash.Models;
using DineNDash.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace DineNDash.ViewModels
{
    public class CreditInfoPageViewModel : BindableBase, INavigationAware
    {
        INavigationService nav_service;
        IPageDialogService _pageDialogService;
        IRepository _repo;

        public DelegateCommand CreditInfoPageCommand { get; set; }
        public DelegateCommand GoBackToPaymentPageCommand { get; set; }

        private string name_entry;
        public string NameEntry
        {
            get { return name_entry; }
            set { SetProperty(ref name_entry, value); }
        }

        private string cardNumber_entry;
        public string CardNumberEntry
        {
            get { return cardNumber_entry; }
            set { SetProperty(ref cardNumber_entry, value); }
        }

        private string cardMonth_entry;
        public string CardMonthEntry
        {
            get { return cardMonth_entry; }
            set { SetProperty(ref cardMonth_entry, value); }
        }

        private string cardYear_entry;
        public string CardYearEntry
        {
            get { return cardYear_entry; }
            set { SetProperty(ref cardYear_entry, value); }
        }

        private string cardSecurity_entry;
        public string CardSecurityEntry
        {
            get { return cardSecurity_entry; }
            set { SetProperty(ref cardSecurity_entry, value); }
        }

        private string address_entry;
        public string AddressEntry
        {
            get { return address_entry; }
            set { SetProperty(ref address_entry, value); }
        }

        private string city_entry;
        public string CityEntry
        {
            get { return city_entry; }
            set { SetProperty(ref city_entry, value); }
        }

        private string state_entry;
        public string StateEntry
        {
            get { return state_entry; }
            set { SetProperty(ref state_entry, value); }
        }

        private string zip_entry;
        public string ZipEntry
        {
            get { return zip_entry; }
            set { SetProperty(ref zip_entry, value); }
        }

        List<string> creditCards;
        public List<string> CreditCards
        {
            get { return creditCards; }
            set { SetProperty(ref creditCards, value); }
        }

        private string selectedCard;
        public string SelectedCard
        {
            get { return selectedCard; }
            set { SetProperty(ref selectedCard, value); }
        }

        private string cardPayment;
        public string CardPayment
        {
            get { return cardPayment; }
            set { SetProperty(ref cardPayment, value); }
        }

        public CreditInfoPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IRepository repository)
        {
            nav_service = navigationService;
            _pageDialogService = pageDialogService;
            _repo = repository;

            creditCards = new List<string>()
            {
                "MasterCard",
                "Visa",
                "Discover"
            };

            CardPayment = "Paid with card";

            CreditInfoPageCommand = new DelegateCommand(GoToNextPage);
            GoBackToPaymentPageCommand = new DelegateCommand(BackToPaymentPage);
        }

        private async void BackToPaymentPage()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(BackToPaymentPage)}");

            await nav_service.NavigateAsync("PaymentPage", null);
        }

        private async void GoToNextPage()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(GoToNextPage)}");

            if (string.IsNullOrEmpty(name_entry) || string.IsNullOrEmpty(cardNumber_entry) || string.IsNullOrEmpty(cardMonth_entry) || string.IsNullOrEmpty(cardYear_entry)
                 || string.IsNullOrEmpty(cardSecurity_entry) || string.IsNullOrEmpty(address_entry) || string.IsNullOrEmpty(city_entry)
                 || string.IsNullOrEmpty(state_entry) || string.IsNullOrEmpty(zip_entry) || string.IsNullOrEmpty(selectedCard))
            {
                await _pageDialogService.DisplayAlertAsync("Error", "You must fill out all fields", "Dismiss");
                return;
            }
            else
            {
                if (cardNumber_entry.Length != 16)
                {
                    await _pageDialogService.DisplayAlertAsync("Error", "Card Number is invalid", "Dismiss");
                    return;
                }
                else if (cardSecurity_entry.Length != 3)
                {
                    await _pageDialogService.DisplayAlertAsync("Error", "You must enter a valid CVV", "Dismiss");
                    return;
                }
                else if (cardMonth_entry.Length != 2)
                {
                    await _pageDialogService.DisplayAlertAsync("Error", "You must enter a valid month", "Dismiss");
                    return;
                }
                else if (cardYear_entry.Length != 4)
                {
                    await _pageDialogService.DisplayAlertAsync("Error", "You must enter a valid year", "Dismiss");
                    return;
                }
                else if (state_entry.Length != 2)
                {
                    await _pageDialogService.DisplayAlertAsync("Error", "You must enter a valid year", "Dismiss");
                    return;
                }
                else if (zip_entry.Length != 5)
                {
                    await _pageDialogService.DisplayAlertAsync("Error", "You must enter a valid year", "Dismiss");
                    return;
                }
                else
                {
                    await nav_service.NavigateAsync("ConfirmationPage", null);
                    RestaurantSideItem card_payment = new RestaurantSideItem
                    {
                        Item = this.CardPayment
                    };

                    await _repo.AddItem(card_payment);
                    var navParams = new NavigationParameters();
                    navParams.Add("ItemAdded", navParams);
                    await Task.Delay(1);
                }
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

