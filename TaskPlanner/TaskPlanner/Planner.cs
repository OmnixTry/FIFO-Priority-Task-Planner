using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPlanner
{
    public class Planner
    {
        public FIFOPriorityContainer Container { get; }

        public Planner(FIFOPriorityContainer container)
        {
            Container = container;
        }
        
        public void StartExecution()
        {
            PlannerTask task = Container.EjectTask();
            while (task != null) 
            {
                Console.WriteLine($"Executing task {task.Name}, with priority {task.Priority}, that lasts {task.Time}.");
                ExecuteTask(task);
                Console.WriteLine($"Finished task {task.Name}.");
                task = Container.EjectTask();
            } 

            void ExecuteTask(PlannerTask CurrentTask)
            {
                System.Threading.Thread.Sleep(CurrentTask.Time * 10);
            }

        }
    }
}
