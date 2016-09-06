using GrainInterfaces;
using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrainCollection
{
    public class Employee : Grain, IEmployee
    {
        public Task<int> GetLevel()
        {
            return Task.FromResult(_level);
        }

        public Task Promote(int newLevel)
        {
            _level = newLevel;
            return TaskDone.Done;
        }

        public Task<IManager> GetManager()
        {
            return Task.FromResult(_manager);
        }

        public Task Greeting(IEmployee from, string message)
        {
            Console.WriteLine("{0} said: {1}", from.GetPrimaryKey().ToString(), message);
            return TaskDone.Done;
        }

        public Task SetManager(IManager manager)
        {
            _manager = manager;
            return TaskDone.Done;
        }

        private int _level;
        private IManager _manager;
    }
}
