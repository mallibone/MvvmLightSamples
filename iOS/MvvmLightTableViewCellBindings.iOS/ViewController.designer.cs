// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace MvvmLightTableViewCellBindings.iOS
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView CountdownsTableView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (CountdownsTableView != null) {
				CountdownsTableView.Dispose ();
				CountdownsTableView = null;
			}
		}
	}
}
