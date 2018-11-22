using System;
using Prism.Mvvm;
using Plugin.StoreReview;
using Plugin.StoreReview.Abstractions;
using Syncfusion.SfRating.XForms;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace DineNDash.ViewModels
{
    public class RatingsPageViewModel : BindableBase
    {
        
        public RatingsPageViewModel()
        {
            //SfRating rating = new SfRating();
            //SfRatingItem item = new SfRatingItem
            //{
            //    SelectedView = new Image() { Source = "Angry_selected.png", Aspect = Aspect.Fill },
            //    UnSelectedView = new Image() { Source = "Angry_Unselected.png", Aspect = Aspect.Fill }
            //};
            //SfRatingItem item1 = new SfRatingItem
            //{
            //    SelectedView = new Image() { Source = "UnHappy_selected.png", Aspect = Aspect.Fill },
            //    UnSelectedView = new Image() { Source = "UnHappy_Unselected.png", Aspect = Aspect.Fill }
            //};
            //SfRatingItem item2 = new SfRatingItem
            //{
            //    SelectedView = new Image() { Source = "Neutral_selected.png", Aspect = Aspect.Fill },
            //    UnSelectedView = new Image() { Source = "Neutral_Unselected.png", Aspect = Aspect.Fill }
            //};
            //SfRatingItem item3 = new SfRatingItem
            //{
            //    SelectedView = new Image() { Source = "Happy_selected.png", Aspect = Aspect.Fill },
            //    UnSelectedView = new Image() { Source = "Happy_Unselected.png", Aspect = Aspect.Fill }
            //};
            //SfRatingItem item4 = new SfRatingItem
            //{
            //    SelectedView = new Image() { Source = "Excited_selected.png", Aspect = Aspect.Fill },
            //    UnSelectedView = new Image() { Source = "Excited_Unselected.png", Aspect = Aspect.Fill }
            //};
            //ObservableCollection<SfRatingItem> customItems = new ObservableCollection<SfRatingItem>
            //{
            //    item,
            //    item1,
            //    item2,
            //    item3,
            //    item4
            //};
            //rating.Items = customItems;
            //rating.EnableCustomView = true;

              SfRating rating = new SfRating();
              rating.ItemCount = 5;
              rating.Precision = Precision.Standard;
              rating.ItemSize = 20;
              rating.ItemSpacing = 20;
        }
    }




}

