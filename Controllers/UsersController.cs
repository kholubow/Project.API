using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Project.API.Data;
using Project.API.Dtos;
using Project.API.Helpers;
using Project.API.Models;

namespace Project.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IApplicationRepository _repo;
        private readonly DataContext _context;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;
        public UsersController(IApplicationRepository repo, DataContext context, IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _cloudinaryConfig = cloudinaryConfig;
            _repo = repo;
            _context = context;

            Account acc = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(acc);
        }


        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var usersToReturn = await _repo.GetUsers();

            return Ok(usersToReturn);
        }

/*
        [HttpPost("addPhoto")]
        public async Task<IActionResult> AddPhotoForUser(int userId, [FromForm]PhotoForCreationDto photoForCreationDto)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var userFromRepo = await _repo.GetUser(userId);

            var file = photoForCreationDto.File;

            var uploadResult = new ImageUploadResult();



        }
 */

        [HttpPost("addInstance/{userId}")]
        public async Task<IActionResult> AddInstanceForUser(int userId, [FromBody]InstanceForCreationDto instanceForCreationDto)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userFromRepo = await _repo.GetUser(userId);

            var instanceToCreate = new Instance 
            {
                Content = instanceForCreationDto.Content,
                InstanceStart = instanceForCreationDto.InstanceStart,
                InstanceEnd = instanceForCreationDto.InstanceEnd,
                TypeOfInstance = instanceForCreationDto.TypeOfInstance,
                UserId = userFromRepo.Id,
                Username = userFromRepo.Username,
                UserSurname = userFromRepo.UserSurname,
                Position = userFromRepo.Position
            };

            await _context.Instances.AddAsync(instanceToCreate);
            await _context.SaveChangesAsync();
            return StatusCode(201);

        }


        [HttpGet("getInstances")]
        public async Task<IActionResult> GetInstances()
        {
            var instancesToReturn = await _repo.GetInstances();

            return Ok(instancesToReturn);
        }
        
    }
}
