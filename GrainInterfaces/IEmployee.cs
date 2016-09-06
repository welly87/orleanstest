using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrainInterfaces
{
    public interface IEmployee : IGrainWithGuidKey
    {
        Task<int> GetLevel();

        Task Promote(int newLevel);

        Task<IManager> GetManager();

        Task SetManager(IManager manager);

        Task Greeting(IEmployee from, string message);
    }

    public interface IManager : IGrainWithGuidKey
    {
        Task<IEmployee> AsEmployee();

        Task<IList<IEmployee>> GetDirectReports();

        Task AddDirectReport(IEmployee employee);
    }
}
