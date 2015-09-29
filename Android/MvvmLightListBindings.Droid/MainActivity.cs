using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using GalaSoft.MvvmLight.Helpers;
using MvvmLightListBindings.Droid.ViewModel;

namespace MvvmLightListBindings.Droid
{
    [Activity(Label = "MvvmLightListBindings.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            PeopleListView.Adapter = Vm.People.GetAdapter();

        }

        private MainViewModel Vm => ViewModelLocator.Instance.MainViewModel;

        private Button AddPersonButton => FindViewById<Button>(Resource.Id.AddButton);
        private Button RemovePersonButton => FindViewById<Button>(Resource.Id.RemoveButton);
        private ListView PeopleListView => FindViewById<ListView>(Resource.Id.People);
    }
}

