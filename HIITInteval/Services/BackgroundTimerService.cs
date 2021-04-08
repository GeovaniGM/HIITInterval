using Matcha.BackgroundService;
using System;
using System.Threading.Tasks;

namespace HIITInteval.Services
{
    public class BackgroundTimerService : IPeriodicTask
    {
        public TimeSpan Interval { get; set; }

        public int Laps { get; set; }

        public Task<bool> StartJob()
        {

            throw new NotImplementedException();
        }
    }
}