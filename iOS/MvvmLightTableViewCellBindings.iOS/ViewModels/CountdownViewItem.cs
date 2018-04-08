using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System;

namespace MvvmLightTableViewBindings.iOS.ViewModel
{
    public class CountdownViewItem : ViewModelBase
	{
		DateTime _expirationTimestamp;

		public CountdownViewItem(TimeSpan timespan)
		{
			if (timespan == null) throw new ArgumentNullException (nameof (timespan));
			_expirationTimestamp = DateTime.UtcNow + timespan;
			Countdown ();
		}

		string _remainingTimeString;
		public string RemainingTimeString {
			get {
				return _remainingTimeString;
			}
			set {
				if (value == _remainingTimeString) return;
				_remainingTimeString = value;
                RaisePropertyChanged (nameof (RemainingTimeString));
			}
		}

		private async void Countdown ()
		{
			while (DateTime.UtcNow < _expirationTimestamp)
			{
				TimeSpan remainingTime = _expirationTimestamp - DateTime.UtcNow;
                RemainingTimeString = remainingTime.ToString ("g");
				await Task.Delay(millisecondsDelay: 1000);
			}

			RemainingTimeString = "Timer Expired";
		}
	}

}