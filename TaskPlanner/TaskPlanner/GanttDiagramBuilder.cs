using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPlanner
{
    public class GanttDiagramBuilder
    {
        public class ProcessedTask
        {
            public ProcessedTask(PlannerTask task, int timeInQueue)
            {
                Task = task;
                TimeInQueue = timeInQueue;
            }

            public PlannerTask Task { get; }

            public int TimeInQueue { get; }

            public override string ToString()
            {
                return $"Name {Task.Name}, Priority {Task.Priority}, Time {Task.Time}, Waited {TimeInQueue}.";
            }
        }

        public GanttDiagramBuilder()
        {
            _currentWaitTime = 0;
            _processedTasks = new List<ProcessedTask>();
        }

        public IReadOnlyList<ProcessedTask> Tasks {
            get
            {
                return _processedTasks.AsReadOnly();
            }
        }

        private List<ProcessedTask> _processedTasks;

        private int _currentWaitTime;
        
        public void ProcessNextTaskExecution(PlannerTask task)
        {
            _processedTasks.Add(new ProcessedTask(task, _currentWaitTime));
            _currentWaitTime += task.Time;
        }

        public override string ToString()
        {
            string total = "";
            foreach (ProcessedTask task in _processedTasks)
            {
                total += task.ToString() + "\n";
            }
            return total;
        }
    }
}
