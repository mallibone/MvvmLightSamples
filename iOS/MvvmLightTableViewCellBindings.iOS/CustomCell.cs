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

        private Binding<string, string> _timerBinding;

		public override void PrepareForReuse()
		{
            base.PrepareForReuse();
            _timerBinding?.Detach();
		}

        internal void Configure(CountdownViewItem countdownViewItem)
        {
            _timerBinding = this.SetBinding(() => countdownViewItem.RemainingTimeString, () => RemainingTimeLabel.Text);
        }
    }
}