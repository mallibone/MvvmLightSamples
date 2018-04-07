using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;

namespace MvvmLightTableViewBindings.iOS.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            AddCountdownCommand = new RelayCommand(AddCountdown);
            RemoveCountdownCommand = new RelayCommand(RemoveCountdown);

			Countdowns = new ObservableCollection<CountdownViewItem>();
			Countdowns.Add (new CountdownViewItem(new TimeSpan(0,13,37)));
        }

        public RelayCommand AddCountdownCommand { get; set; }
        public RelayCommand RemoveCountdownCommand { get; set; }
		public ObservableCollection<CountdownViewItem> Countdowns { get; private set; }

		private void AddCountdown()
        {
            var timeSpan = new TimeSpan(0, 0, new Random().Next(0, 120));
			Countdowns.Add(new CountdownViewItem(timeSpan));
        }

        private void RemoveCountdown()
        {
            if (!Countdowns.Any()) return;
            Countdowns.Remove(Countdowns.Last());
        }
    }
}