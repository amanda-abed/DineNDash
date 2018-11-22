using System;

using Xamarin.Forms;

namespace DineNDash.ViewModels
{
    public class TabIndivItemPageViewModel : ContentPage
    {
        public TabIndivItemPageViewModel()
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

