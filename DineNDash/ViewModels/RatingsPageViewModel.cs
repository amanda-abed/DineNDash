using System;
using Prism.Mvvm;
using Plugin.StoreReview;
using Plugin.StoreReview.Abstractions;
using Syncfusion.SfRating.XForms;
using Xamarin.Forms;
using Plugin.DeviceInfo;
using Plugin.DeviceInfo.Abstractions;
using System.Collections.ObjectModel;

namespace DineNDash.ViewModels
{
    public class RatingsPageViewModel : BindableBase
    {
        
        public RatingsPageViewModel()
        {
            var url = string.Empty;
            var appId = string.Empty;

            if (Plugin.DeviceInfo.CrossDeviceInfo.Current.Platform == Platform.iOS)
            {
                appId = "DineNDash";
                url = $"itms-apps://itunes.apple.com/WebObjects/MZStore.woa/wa/viewContentsUserReviews?id={appId}&amp;onlyLatestVersion=true&amp;pageNumber=0&amp;sortOrdering=1&amp;type=Purple+Software";
            }
            else if (Plugin.DeviceInfo.CrossDeviceInfo.Current.Platform == Platform.Android)
            {
                appId = "com.companyname.DineNDash";
                url = $"https://play.google.com/store/apps/details?id={appId}";
            }
            Plugin.StoreReview.CrossStoreReview.Current.OpenStoreListing(appId);
        }
    }




}

