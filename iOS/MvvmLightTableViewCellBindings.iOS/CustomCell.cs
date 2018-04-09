using Foundation;
using GalaSoft.MvvmLight.Helpers;
using MvvmLightTableViewBindings.iOS.ViewModel;
using System;
using UIKit;

namespace MvvmLightTableViewCellBindings.iOS
{
    public partial class CustomCell : UITableViewCell
    {

        CountdownViewItem _countdownViewItem;

        public CustomCell (IntPtr handle) : base (handle)
        {
        }

        public Binding<string, string> _timerBinding;

        public override void PrepareForReuse()
		{
            base.PrepareForReuse();
            _timerBinding?.Detach();
		}

        internal void Configure(CountdownViewItem countdownViewItem)
        {
            _countdownViewItem = countdownViewItem;
            _timerBinding = this.SetBinding(() => _countdownViewItem.RemainingTimeString, () => RemainingTimeLabel.Text);
        }
    }
}