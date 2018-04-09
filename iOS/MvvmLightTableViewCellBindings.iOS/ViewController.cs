using System;
using UIKit;
using GalaSoft.MvvmLight.Helpers;
using MvvmLightTableViewBindings.iOS.ViewModel;
using Foundation;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

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
            //CountdownsTableView.Source = new GenericTableViewSource<CountdownViewItem>(Vm.Countdowns, CreatePersonCell, BindCellDelegate);

            AddTimerButton.SetCommand("TouchUpInside", Vm.AddCountdownCommand);
		}

		private void BindCellDelegate(UITableViewCell cell, CountdownViewItem countdownViewItem, NSIndexPath path)
		{
            var bindableCell = (CustomCell) cell;
            bindableCell.Configure(countdownViewItem);
        }

		private UITableViewCell CreatePersonCell(NSString cellIdentifier)

        //private UITableViewCell CreatePersonCell(CountdownViewItem countdownViewItem)
		{
            return CountdownsTableView.DequeueReusableCell("TimerCell");
		}
	}

    public class GenericTableViewSource<T> : UITableViewSource
    {
        readonly T[] _collection;
        private Func<T, UITableViewCell> _createCell;
        private Action<UITableViewCell, T, NSIndexPath> _bindCell;
        private Action _cellSelected;

        public GenericTableViewSource(IEnumerable<T> collection, Func<T, UITableViewCell> createCell, Action<UITableViewCell, T, NSIndexPath> bindCell)
        {
            _collection = collection?.ToArray() ?? throw new ArgumentNullException(nameof(collection));
            _createCell = createCell ?? throw new ArgumentNullException(nameof(createCell));
            _bindCell = bindCell ?? throw new ArgumentNullException(nameof(bindCell));

        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var item = _collection[indexPath.Row];
            var cell = _createCell.Invoke(item);

            _bindCell.Invoke(cell, item, indexPath);

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _collection.Length;
        }
    }
}

