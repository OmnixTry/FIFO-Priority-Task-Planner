using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPlanner
{
    public class PlannerTask
    {
        public string Name { get; }

        public int Time { get; }

        public int Priority { get; }

        public PlannerTask(string name, int time, int priority)
        {
            Name = name;
            Priority = priority;
            Time = time;
        }
    }
}
