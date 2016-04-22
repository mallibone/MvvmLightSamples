using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace MvvmLightBindings.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private string _inputText;
        private string _submittedMessage;

        public MainViewModel()
        {
            SubmitMessageCommand = new RelayCommand<string>(SubmitMessage);
        }

        public RelayCommand<string> SubmitMessageCommand { get; private set; }

        private void SubmitMessage(string message)
        {
            SubmittedMessage = message;
        }

        public string SubmittedMessage
        {
            get { return _submittedMessage; }
            set
            {
                _submittedMessage = value;
                RaisePropertyChanged(propertyName: nameof(SubmittedMessage));
            }
        }

        public string InputMessage
        {
            get { return _inputText; }
            set
            {
                _inputText = value;
                RaisePropertyChanged(propertyName: nameof(InputMessage));
            }
        }
    }
}