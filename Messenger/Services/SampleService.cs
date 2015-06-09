using System.Threading.Tasks;
using Messenger.Messages;

namespace Messenger.Services
{
    class SampleService:ISampleService
    {
        private int _invokedCount = 0;

        public async void NonBlockingAsyncMethod()
        {
            _invokedCount += 1;
            await Task.Delay(3000);

            GalaSoft.MvvmLight.Messaging.Messenger.Default.Send(new SampleMessage(_invokedCount));
        }
    }
}
