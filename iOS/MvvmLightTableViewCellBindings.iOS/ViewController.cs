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
//			AddPersonButton.SetCommand("TouchUpInside", Vm.AddPersonCommand);
//			RemovePersonButton.SetCommand("TouchUpInside", Vm.RemovePersonCommand);
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			_tableViewController = Vm.Countdowns.GetController(CreatePersonCell, BindCellDelegate);
			_tableViewController.TableView = CountdownsTableView;
		}

		private void BindCellDelegate(UITableViewCell cell, CountdownViewItem countdownViewItem, NSIndexPath path)
		{
			var bindableCell = (BindableTextCell) cell;
//			bindableCell.TextLabel.Text = person.FullName;
			bindableCell.TextBinding = this.SetBinding(() => countdownViewItem.RemainingTimeString, () => bindableCell.TextLabel.Text);
//			bindableCell.TextLabel.Text = countdownViewItem.RemainingTimeString;
		}

		private UITableViewCell CreatePersonCell(NSString cellIdentifier)
		{
			return new BindableTextCell("Gnabber");
//			return new BindableTextCell(base.Handle);
		}
	}

	public class BindableTextCell : UITableViewCell
	{
		public BindableTextCell(string identifier):base(UITableViewCellStyle.Default, identifier){
			
		}

		public Binding<string, string> TextBinding;
		
	}
}

