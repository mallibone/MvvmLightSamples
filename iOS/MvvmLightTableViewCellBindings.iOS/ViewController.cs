using System;

using UIKit;
using GalaSoft.MvvmLight.Helpers;
using MvvmLightTableViewBindings.iOS.ViewModel;
using Foundation;

namespace MvvmLightTableViewCellBindings.iOS
{
	public partial class ViewController : UIViewController
	{
		private ObservableTableViewController<CountdownViewItem> _tableViewController;
		private MainViewModel Vm => Application.ViewModelLocator.MainViewModel;

		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Setup bindings

            _tableViewController = Vm.Countdowns.GetController(CreatePersonCell, BindCellDelegate);
            _tableViewController.TableView = CountdownsTableView;

            AddTimerButton.SetCommand("TouchUpInside", Vm.AddCountdownCommand);
		}

		private void BindCellDelegate(UITableViewCell cell, CountdownViewItem countdownViewItem, NSIndexPath path)
		{
            var bindableCell = (CustomCell) cell;
            bindableCell.Configure(countdownViewItem);
        }

		private UITableViewCell CreatePersonCell(NSString cellIdentifier)
		{
            return _tableViewController.TableView.DequeueReusableCell("TimerCell");
		}
	}

}

