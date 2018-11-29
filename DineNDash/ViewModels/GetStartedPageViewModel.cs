using System;
using System.Diagnostics;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace DineNDash.ViewModels
{
    public class GetStartedPageViewModel : BindableBase, INavigationAware
    {
        INavigationService _navigationService;

        public DelegateCommand GetStartedCommand { get; set; }
        public DelegateCommand LearnMoreCommand { get; set; }

        public GetStartedPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            GetStartedCommand = new DelegateCommand(OnToMainPage);
            LearnMoreCommand = new DelegateCommand(OnToLearnMorePage);
        }

        private async void OnToLearnMorePage()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnToLearnMorePage)}");

            await _navigationService.NavigateAsync("LearnMorePage", null); ;
        }

        private async void OnToMainPage()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnToMainPage)}");

            await _navigationService.NavigateAsync("MainPage", null); 
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

