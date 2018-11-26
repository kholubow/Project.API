using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.API.Data;
using Project.API.Models;

namespace Project.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]    
    public class UsersController : Controller
    {
        private readonly IApplicationRepository _repo;
        private readonly DataContext _context;
        public UsersController(IApplicationRepository repo, DataContext context)
        {
            _repo = repo;
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var usersToReturn = await _repo.GetUsers();

            return Ok(usersToReturn);
        }
    }
}
