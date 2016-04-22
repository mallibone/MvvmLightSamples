using System.Linq;
using Android.App;
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
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            CountdownsListView.Adapter = Vm.Countdowns.GetAdapter(GetCountdownRow);
        }

        private View GetCountdownRow(int position, CountdownViewItem countdownViewItem, View countdownRow)
        {
            View view = countdownRow ?? LayoutInflater.Inflate(Resource.Layout.CountdownRow, null);
            var viewHolder = view.Tag as CountdownViewHolder ?? CreateCountdownViewHolder(view);

            view.FindViewById<TextView>(Resource.Id.CountdownText).Text = countdownViewItem.RemainingTimeString;

            viewHolder.CountdownBinding = this.SetBinding(() => Vm.Countdowns.First(c => c.Equals(countdownViewItem)).RemainingTimeString,
                () => view.FindViewById<TextView>(Resource.Id.CountdownText).Text);

            view.Tag = viewHolder;


            return view;
        }

        private CountdownViewHolder CreateCountdownViewHolder(View view)
        {
            var viewHolder = new CountdownViewHolder
            {
                Countdown = view.FindViewById<TextView>(Resource.Id.CountdownText)
            };

            return viewHolder;
        }

        private MainViewModel Vm => ViewModelLocator.Instance.MainViewModel;
        private ListView CountdownsListView => FindViewById<ListView>(Resource.Id.CountdownsListView);


        public class CountdownViewHolder : Java.Lang.Object
        {
            public Binding CountdownBinding { get; set; }
            public TextView Countdown { get; set; }
        }
    }
}

