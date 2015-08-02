using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace MvvmLightBindings.Droid.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private string _message;
        private string _previousMessage;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            MessageCommand = new RelayCommand<string>(SubmitMessage);
        }

        public RelayCommand<string> MessageCommand { get; private set; }

        private void SubmitMessage(string message)
        {
            PreviousMessage = message;
        }

        public string PreviousMessage
        {
            get { return _previousMessage; }
            set
            {
                _previousMessage = value;
                RaisePropertyChanged(propertyName: nameof(PreviousMessage));
            }
        }

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                RaisePropertyChanged(propertyName: nameof(Message));
            }
        }
    }
}