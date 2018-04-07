// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
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
        UIKit.UIButton AddTimerButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView CountdownsTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (AddTimerButton != null) {
                AddTimerButton.Dispose ();
                AddTimerButton = null;
            }

            if (CountdownsTableView != null) {
                CountdownsTableView.Dispose ();
                CountdownsTableView = null;
            }
        }
    }
}