using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace MvvmLightBindings.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private string _inputText = string.Empty;
        private string _submittedMessage = string.Empty;

        public MainViewModel()
        {
            SubmitMessageCommand = new RelayCommand(SubmitMessage);
        }

        public RelayCommand SubmitMessageCommand { get; private set; }

        private void SubmitMessage()
        {
            SubmittedMessage = InputMessage;
        }

        public string SubmittedMessage
        {
            get { return _submittedMessage; }
            set
            {
                if (value == _submittedMessage) return;
                _submittedMessage = value;
                RaisePropertyChanged(nameof(SubmittedMessage));
            }
        }

        public string InputMessage
        {
            get { return _inputText; }
            set
            {
                _inputText = value;
                RaisePropertyChanged(nameof(InputMessage));
            }
        }
    }
}