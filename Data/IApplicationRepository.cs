using System.Collections.Generic;
using System.Threading.Tasks;
using Project.API.Models;

namespace Project.API.Data
{
    public interface IApplicationRepository
    {
        Task<List<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<List<Instance>> GetInstances();
        Task<List<Instance>> GetInstancesForWorker(int id);
    }
}
