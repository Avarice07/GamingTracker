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
        public DateTime Duration { get; set; }

        public GamingSession() { 
        
        }

        public GamingSession(int Id, DateTime StartTime, DateTime EndTime, DateTime Duration)    
        { 
            this.Id = Id;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.Duration = Duration;
        }

        DateTime

    }
}
