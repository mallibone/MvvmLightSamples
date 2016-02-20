using System;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace MvvmLightListRowBindings.Droid.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            AddCountdownCommand = new RelayCommand(AddCountdown);
            RemoveCountdownCommand = new RelayCommand(RemoveCountdown);

			Countdowns = new ObservableCollection<CountdownViewItem>();
			Countdowns.Add (new CountdownViewItem(new TimeSpan(13,37,0)));
//			Countdowns.Add (new CountdownViewItem(new TimeSpan(0,13,37)));
//			Countdowns.Add (new CountdownViewItem(new TimeSpan(0,42,0)));
        }

        public RelayCommand AddCountdownCommand { get; set; }
        public RelayCommand RemoveCountdownCommand { get; set; }
		public ObservableCollection<CountdownViewItem> Countdowns { get; private set; }

		private void AddCountdown()
        {
//			Countdowns.Add(new CountdownViewItem(timeSpan));
        }

        private void RemoveCountdown()
        {
            if (!Countdowns.Any()) return;
            Countdowns.Remove(Countdowns.Last());
        }
    }
}