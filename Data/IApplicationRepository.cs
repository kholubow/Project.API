using System.Collections.Generic;
using System.Threading.Tasks;
using Project.API.Models;

namespace Project.API.Data
{
    public interface IApplicationRepository
    {
        Task<List<User>> GetUsers();
    }
}
