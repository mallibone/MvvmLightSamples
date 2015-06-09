using GalaSoft.MvvmLight.Messaging;

namespace Messenger.Messages
{
    internal class SampleMessage:MessageBase
    {
        public SampleMessage(int invokedCount):base()
        {
            InvokedCount = invokedCount;
        }

        public int InvokedCount { get; set; }
    }
}