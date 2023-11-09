using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingTracker
{
    internal class GamingSession
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Duration { get; set; }

        public GamingSession() { 
        
        }
        public GamingSession(int Id, DateTime StartTime)
        {
            this.Id = Id;
            this.StartTime = StartTime;
           
        }

        public GamingSession(int Id, DateTime StartTime, DateTime EndTime, TimeSpan Duration)    
        { 
            this.Id = Id;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.Duration = StartTime.Subtract(EndTime);
        }

        TimeSpan TimeDiff(DateTime start, DateTime end)
        {
            return start.Subtract(end);
        }

    }
}
