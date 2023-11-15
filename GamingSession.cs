using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingTracker
{
    internal class GamingSession
    {
        public static int Counter = 0;
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Duration { get; set; }

        public GamingSession() { 
        
        }
        public GamingSession(DateTime StartTime)
        {
            Id = Counter;
            this.StartTime = StartTime;
            Counter += Counter;
        }

        public GamingSession(DateTime StartTime, DateTime EndTime)    
        { 
            Id = Counter;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            Duration = StartTime.Subtract(EndTime);
            Counter += Counter;
        }

        public GamingSession(int Id, DateTime StartTime, DateTime EndTime, TimeSpan Duration)
        {
            this.Id = Id;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.Duration = StartTime.Subtract(EndTime);
        }

    }
}
