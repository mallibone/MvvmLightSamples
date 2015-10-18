using System;
using System.Drawing;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using MvvmLightTableViewBindings.iOS.Models;
using MvvmLightTableViewBindings.iOS.ViewModel;
using UIKit;

namespace MvvmLightTableViewBindings.iOS
{
    public partial class RootViewController : UIViewController
    {
        private ObservableTableViewController<Person> _tableViewController;
        private MainViewModel Vm => Application.ViewModelLocator.MainViewModel;
        public RootViewController(IntPtr handle) : base(handle)
        {
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            await Vm.InitAsync();

            AddPersonButton.SetCommand("TouchUpInside", Vm.AddPersonCommand);
            RemovePersonButton.SetCommand("TouchUpInside", Vm.RemovePersonCommand);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            _tableViewController = Vm.People.GetController(CreatePersonCell, BindCellDelegate);
            _tableViewController.TableView = PeopleTableView;
        }

        private void BindCellDelegate(UITableViewCell cell, Person person, NSIndexPath path)
        {
            cell.TextLabel.Text = person.FullName;
        }

        private UITableViewCell CreatePersonCell(NSString cellIdentifier)
        {
            return new UITableViewCell(UITableViewCellStyle.Default, "Gnabber");
        }
    }
}