using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using GalaSoft.MvvmLight.Helpers;

namespace MvvmLightTableViewCellBindings.iOS
{
	partial class BindableTextCell : UITableViewCell
	{
		public Binding<string, string> TextBinding {
			get;
			set;
		}

		public BindableTextCell (IntPtr handle) : base (handle)
		{
		}
	}
}
