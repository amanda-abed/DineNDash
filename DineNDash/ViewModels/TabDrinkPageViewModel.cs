using System;

using Xamarin.Forms;

namespace DineNDash.ViewModels
{
    public class TabDrinkPageViewModel : ContentPage
    {
        public TabDrinkPageViewModel()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

