using Foundation;
using GalaSoft.MvvmLight.Helpers;
using MvvmLightTableViewBindings.iOS.ViewModel;
using System;
using UIKit;

namespace MvvmLightTableViewCellBindings.iOS
{
    public partial class CustomCell : UITableViewCell
    {
        public CustomCell (IntPtr handle) : base (handle)
        {
        }

        public Binding<string, string> _timerBinding;
        public string RemainingTimeText
        {
            get
            {
                return RemainingTimeLabel.Text;
            }

            set
            {
                RemainingTimeLabel.Text = value;
            }
        }

        public override void PrepareForReuse()
		{
            base.PrepareForReuse();
            _timerBinding?.Detach();
		}

        internal void Configure(CountdownViewItem countdownViewItem)
        {
            _timerBinding = new Binding<string, string>(countdownViewItem, "RemainingTimeString", mode: BindingMode.OneWay).WhenSourceChanges(() => RemainingTimeText = countdownViewItem.RemainingTimeString);
            //_timerBinding = this.SetBinding(() => countdownViewItem.RemainingTimeString, () => RemainingTimeText);
        }
    }
}