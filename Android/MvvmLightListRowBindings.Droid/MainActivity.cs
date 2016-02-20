using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using GalaSoft.MvvmLight.Helpers;
using MvvmLightListRowBindings.Droid.ViewModels;

namespace MvvmLightListRowBindings.Droid
{
    [Activity(Label = "MvvmLightListRowBindings.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            CountdownsListView.Adapter = Vm.Countdowns.GetAdapter(GetCountdownRow);

        }

        private View GetCountdownRow(int position, CountdownViewItem countdownViewItem, View countdownRow)
        {
            View view = countdownRow ?? LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);

            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = countdownViewItem.RemainingTimeString;

            return view;
        }

        private MainViewModel Vm => ViewModelLocator.Instance.MainViewModel;
    }
}

