using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalServiceAutomation
{
    public class VirtualClock
    {
        public TimeSpan time;

        public VirtualClock(TimeSpan StartTime)
        {
            this.time = StartTime;
        }

        public void Tick() 
        {
            TimeSpan SimulationSpeed = new TimeSpan(0,05,0);
            time = time.Add(SimulationSpeed);
        }
        public void ResetClock()
        {
            time = TimeSpan.Zero;
        }
    }
}
