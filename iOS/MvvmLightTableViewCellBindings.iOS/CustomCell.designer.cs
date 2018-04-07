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
    [Register ("CustomCell")]
    partial class CustomCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel RemainingTimeLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (RemainingTimeLabel != null) {
                RemainingTimeLabel.Dispose ();
                RemainingTimeLabel = null;
            }
        }
    }
}