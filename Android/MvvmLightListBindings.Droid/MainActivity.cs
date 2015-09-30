using Android.App;
using Android.Views;
using Android.Widget;
using Android.OS;
using GalaSoft.MvvmLight.Helpers;
using MvvmLightListBindings.Droid.Models;
using MvvmLightListBindings.Droid.ViewModel;

namespace MvvmLightListBindings.Droid
{
    [Activity(Label = "MvvmLightListBindings.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            await Vm.InitAsync();
            PeopleListView.Adapter = Vm.People.GetAdapter(GetPersonView);
            AddPersonButton.SetCommand("Click", Vm.AddPersonCommand);
            RemovePersonButton.SetCommand("Click", Vm.RemovePersonCommand);
        }

        private View GetPersonView(int position, Person person, View convertView)
        {
            View view = convertView ?? LayoutInflater.Inflate(Resource.Layout.RowPerson, null);

            var firstName = view.FindViewById<TextView>(Resource.Id.FirstName);
            var lastName = view.FindViewById<TextView>(Resource.Id.LastName);

            firstName.Text = person.FirstName;
            lastName.Text = person.LastName;

            return view;
        }

        private MainViewModel Vm => ViewModelLocator.Instance.MainViewModel;

        private Button AddPersonButton => FindViewById<Button>(Resource.Id.AddButton);
        private Button RemovePersonButton => FindViewById<Button>(Resource.Id.RemoveButton);
        private ListView PeopleListView => FindViewById<ListView>(Resource.Id.People);
    }
}

