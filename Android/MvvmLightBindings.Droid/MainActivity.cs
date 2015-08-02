using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using GalaSoft.MvvmLight.Helpers;
using MvvmLightBindings.Droid.ViewModel;

namespace MvvmLightBindings.Droid
{
    [Activity(Label = "MvvmLightBindings.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private EditText _editMessage;
        private MainViewModel _vm;
        private Button _messageButton;
        private Binding<string, string> _messageBinding;
        private Binding<string, string> _textViewBinding;
        private TextView _previousMessage;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //_lockBinding = this.SetBinding(
            //    () => Vm.IsLocked,
            //    () => LockCheckBox.Checked,
            //    BindingMode.TwoWay);

            _messageBinding = this.SetBinding(() => EditMessage.Text);

            MessageButton.SetCommand("Click", Vm.MessageCommand, _messageBinding);

            _textViewBinding = this.SetBinding(() => Vm.PreviousMessage, () => PreviousMessage.Text);

        }

        public MainViewModel Vm => _vm ?? (_vm = App.Locator.Main);

        public EditText EditMessage
        {
            get
            {
                return _editMessage
                       ?? (_editMessage = FindViewById<EditText>(Resource.Id.MessageText));
            }
        }
        public TextView PreviousMessage
        {
            get
            {
                return _previousMessage
                       ?? (_previousMessage = FindViewById<TextView>(Resource.Id.SubmittedMessage));
            }
        }
        public Button MessageButton
        {
            get
            {
                return _messageButton
                       ?? (_messageButton = FindViewById<Button>(Resource.Id.SubmitMessage));
            }
        }
    }
}

