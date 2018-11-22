using System;
using System.Collections.Generic;
using System.Diagnostics;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace DineNDash.ViewModels
{
    public class ChooseSeatingPageViewModel : BindableBase, INavigationAware
    {
        INavigationService nav_service;
        IPageDialogService _pageDialogService;

        public DelegateCommand GoToMenuPage { get; set; }

        private string selectedSeat;
        public string SelectedSeat
        {
            get { return selectedSeat; }
            set { SetProperty(ref selectedSeat, value); }
        }

        List<string> availableSeats;
        public List<string> AvailableSeats
        {
            get { return availableSeats; }
            set { SetProperty(ref availableSeats, value); }
        }

        public ChooseSeatingPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            nav_service = navigationService;
            _pageDialogService = pageDialogService;

            availableSeats = new List<string>()
            {
                "1","2","3","4","5","6","7"
            };

            GoToMenuPage = new DelegateCommand(OntoNextPage);
        }

        private async void OntoNextPage()
        {
            if (string.IsNullOrEmpty(selectedSeat))
            {
                await _pageDialogService.DisplayAlertAsync("Error", "Must select a seat", "Dismiss");
                return;
            }
            else
            {
                await nav_service.NavigateAsync("MenuOneContainerPage", null);
            }
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatedTo)}");
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatedFrom)}");
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatedTo)}");
        }
    }
}

