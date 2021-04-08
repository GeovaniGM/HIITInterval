using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HIITInteval
{
    public class MainViewModel : ObservableObject
    {

        #region Constructors
        public MainViewModel()
        {

        }
        #endregion -- Constructors --


        #region Commands
        public Command StartTimerCommand => new Command(async () => await StartTimer());

        public Command StopTimerCommand => new Command(async () => StopTimer());

        public Command ResetTimerCommand => new Command(async () => SetTimerValues());
        #endregion -- Commands --


        #region Methods
        public async Task StartTimer()
        {
            ResetEnabled = false;
            LapsLeft = NumberOfLaps;
            LapTimeLeft = LapTime;

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                if (NeedStopTimer)
                    return false;

                if (LapTimeLeft.TotalSeconds > 0)
                {
                    LapTimeLeft = LapTimeLeft.Subtract(TimeSpan.FromSeconds(1));
                    return true;
                }

                Vibration.Vibrate(2000);

                if (LapsLeft == 0)
                {
                    ResetEnabled = true;
                    return false;
                }

                LapsLeft--;
                LapTimeLeft = LapTime;
                return true;
            });

            NeedStopTimer = false;
        }

        public void StopTimer()
        {
            ResetEnabled = true;
            NeedStopTimer = true;
        }

        public void SetTimerValues()
        {
            LapTimeLeft = LapTime;
            LapsLeft = NumberOfLaps;
        }
        #endregion -- Methods --


        #region Properties
        private TimeSpan lapTimeLeft;
        public TimeSpan LapTimeLeft
        {
            get { return lapTimeLeft; }
            set { SetProperty(ref lapTimeLeft, value); }
        }

        private TimeSpan lapTime;
        public TimeSpan LapTime
        {
            get { return lapTime; }
            set { SetProperty(ref lapTime, value); }
        }

        private int numberOfLaps;
        public int NumberOfLaps
        {
            get { return numberOfLaps; }
            set { SetProperty(ref numberOfLaps, value); }
        }

        private int lapsLeft;
        public int LapsLeft
        {
            get { return lapsLeft; }
            set { SetProperty(ref lapsLeft, value); }
        }

        bool NeedStopTimer { get; set; }

        private bool resetEnabled = false;
        public bool ResetEnabled
        {
            get { return resetEnabled; }
            set { SetProperty(ref resetEnabled, value); }
        }
        #endregion -- Properties --
    }
}