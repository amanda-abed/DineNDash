using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Plugin.ExternalMaps;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace DineNDash.ViewModels
{
    public class DineNDashHomePageViewModel : BindableBase
    {
        INavigationService _navigationService;
        public DelegateCommand GoToMapCommand { get; set; }
        public DelegateCommand searchActivated { get; set; }
        public DelegateCommand<string> SuggestionTappedCommand { get; set; }

        private string enter_restaurant;
        public string EnterRestaurant
        {
            get { return enter_restaurant; }
            set { SetProperty(ref enter_restaurant, value); }
        }

        private bool is_visible;
        public bool IsVisible
        {
            get { return is_visible; }
            set { SetProperty(ref is_visible, value); }
        }

        List<string> restaurants = new List<string>
        {
            "In-N-Out Burger"
        };

        //private List<string> my_restaurant = new List<string>();
        //public List<string> MyRestaurant
        //{ get { return my_restaurant; } set { SetProperty(ref my_restaurant, value); } }

        private List<string> _suggestions = new List<string>();
        public List<string> Suggestions
        { get { return _suggestions; } set { SetProperty(ref _suggestions, value); } }

        public DineNDashHomePageViewModel(INavigationService navigationService)
        {
            Debug.WriteLine($"**** {this.GetType().Name}: ctor");

            _navigationService = navigationService;

            GoToMapCommand = new DelegateCommand(GoToMap);
            searchActivated = new DelegateCommand(GoToSearch);
            SuggestionTappedCommand = new DelegateCommand<string>(OnSuggestionTapped);
        }

        private void GoToSearch()
        {
            if (enter_restaurant.Length >= 1){
                Suggestions = restaurants.Where(c => c.ToLower().Contains(enter_restaurant.ToLower())).ToList();

                IsVisible = true;
            }
            else{
                IsVisible = false;
            }
        }

        private async void OnSuggestionTapped(string suggestionTapped)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnSuggestionTapped)}:  {suggestionTapped}");

            await _navigationService.NavigateAsync("ChooseSeatingPage", null);
            IsVisible = false;
        }

        private void GoToMap()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(GoToMap)}");
            CrossExternalMaps.Current.NavigateTo("In-N-Out Burger", "583 Grand Ave", "San Marcos", "CA", "92078", "USA", "USA");
        }

    }


}