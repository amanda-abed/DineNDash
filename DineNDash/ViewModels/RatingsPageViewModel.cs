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
            Plugin.StoreReview.CrossStoreReview.Current.OpenStoreReviewPage("com.companyname.DineNDash");
        }
    }




}

