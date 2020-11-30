using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPlanner
{
    public class FIFOPriorityContainer
    {
        private Dictionary<int, Queue<PlannerTask>> Queues { get; }
        
        public int MaxPriority { get; }

        public delegate void ElemRemovedDelegate(PlannerTask task);

        public event ElemRemovedDelegate OnElementRemoved;

        private int _currentBiggestPriority;
        

        public FIFOPriorityContainer(int maxPriority)
        {
            MaxPriority = maxPriority;
            Queues = new Dictionary<int, Queue<PlannerTask>>();
            initPriorities();
            _currentBiggestPriority = maxPriority + 1;

            void initPriorities()
            {
                for (int i = 0; i <= MaxPriority; i++)
                {
                    Queues.Add(i, new Queue<PlannerTask>());
                }
            }
        }

        public void AddTask(PlannerTask task)
        {
            Queues[task.Priority].Enqueue(task);
            if (task.Priority < _currentBiggestPriority)
                _currentBiggestPriority = task.Priority;
        }

        public PlannerTask EjectTask()
        {
            // when there's no elements
            if (_currentBiggestPriority > MaxPriority)
                return null;

            PlannerTask task = Queues[_currentBiggestPriority].Dequeue();
            while (_currentBiggestPriority <= MaxPriority && Queues[_currentBiggestPriority].Count() == 0)
                _currentBiggestPriority++;
            OnElementRemoved.Invoke(task);

            return task;
        }

        public void DisplayEnqued()
        {
            foreach (var key in Queues.Keys)
            {
                DisplayQueue(key);
            }

            void DisplayQueue(int key)
            {
                Queue<PlannerTask> tasks = Queues[key];
                if (tasks.Count != 0)
                {
                    Console.WriteLine($"Tasks with priority {key}:");
                    foreach (var task in tasks)
                    {
                        Console.WriteLine($"\t\t{task.Name}, {task.Time}, {task.Priority}.");
                    }
                    Console.WriteLine();
                }
            }
        }


    }
}
