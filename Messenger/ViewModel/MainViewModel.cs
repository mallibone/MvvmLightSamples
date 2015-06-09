using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Messenger.Messages;
using Messenger.Services;

namespace Messenger.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ISampleService _sampleService;
        private string _invokedMessage;
        private bool _canInvokeService;

        private const string LabelTextTemplate = "The sample service has been invoked {0} times.";

        public MainViewModel(ISampleService sampleService)
        {
            if (sampleService == null) throw new ArgumentNullException("sampleService");
            _sampleService = sampleService;

            if (IsInDesignMode)
            {
                InvokedMessage = string.Format(LabelTextTemplate, 42);
            }
            else
            {
                InvokedMessage = "Invoke the service by pushing the button.";
            }

            InvokeServiceCommand = new RelayCommand(InvokeService, () => CanInvokeService);

            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<SampleMessage>(this, ReceiveSampleMessage);
            CanInvokeService = true;
        }

        #region properties
        public bool CanInvokeService
        {
            get { return _canInvokeService; }
            set
            {
                if (_canInvokeService == value) return;
                _canInvokeService = value;
                RaisePropertyChanged(() => CanInvokeService);
            }
        }

        public string InvokedMessage
        {
            get { return _invokedMessage; }
            set
            {
                if (_invokedMessage == value) return;
                _invokedMessage = value;
                RaisePropertyChanged(() => InvokedMessage);
            }
        }

        public ICommand InvokeServiceCommand { get; set; }
        #endregion

        #region methods
        private void InvokeService()
        {
            CanInvokeService = false;

            _sampleService.NonBlockingAsyncMethod();
        }

        private void ReceiveSampleMessage(SampleMessage message)
        {
            CanInvokeService = true;
            InvokedMessage = string.Format(LabelTextTemplate, message.InvokedCount);
        }
        #endregion
    }
}