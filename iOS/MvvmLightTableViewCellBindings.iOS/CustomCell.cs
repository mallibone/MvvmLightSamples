using Foundation;
using GalaSoft.MvvmLight.Helpers;
using System;
using UIKit;

namespace MvvmLightTableViewCellBindings.iOS
{
    public partial class CustomCell : UITableViewCell
    {
        public CustomCell (IntPtr handle) : base (handle)
        {
        }

        public Binding Binding { get; set; }

		public override void PrepareForReuse()
		{
            base.PrepareForReuse();
            Binding.Detach();
		}
	}
}