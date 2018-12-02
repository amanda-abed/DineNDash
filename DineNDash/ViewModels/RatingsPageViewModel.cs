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
            string appId = "com.companyname.DineNDash";
            Plugin.StoreReview.CrossStoreReview.Current.OpenStoreListing(appId);
        }
    }




}

