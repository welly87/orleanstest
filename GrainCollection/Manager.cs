using GrainInterfaces;
using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrainCollection
{
    public class Manager : Grain, IManager
    {
        private IEmployee _me;
        private IList<IEmployee> _reports = new List<IEmployee>();

        public override Task OnActivateAsync()
        {
            _me = this.GrainFactory.GetGrain<IEmployee>(this.GetPrimaryKey());

            return base.OnActivateAsync();
        }

        public async Task AddDirectReport(IEmployee employee)
        {
            _reports.Add(employee);
            await employee.SetManager(this);
            await employee.Greeting(_me, "Welcome to my team!");
            //return TaskDone.Done;
        }

        public Task<IEmployee> AsEmployee()
        {
            return Task.FromResult(_me);
        }

        public Task<IList<IEmployee>> GetDirectReports()
        {
            return Task.FromResult(_reports);
        }
    }
}
