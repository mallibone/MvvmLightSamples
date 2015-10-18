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

namespace MvvmLightTableViewBindings.iOS
{
	[Register ("RootViewController")]
	partial class RootViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton AddPersonButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView PeopleTableView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton RemovePersonButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (AddPersonButton != null) {
				AddPersonButton.Dispose ();
				AddPersonButton = null;
			}
			if (PeopleTableView != null) {
				PeopleTableView.Dispose ();
				PeopleTableView = null;
			}
			if (RemovePersonButton != null) {
				RemovePersonButton.Dispose ();
				RemovePersonButton = null;
			}
		}
	}
}
