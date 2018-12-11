using System;
using Microsoft.AspNetCore.Http;

namespace Project.API.Dtos
{
    public class PhotoForCreationDto
    {
        public string Url { get; set; }
        public IFormFile File { get; set; }
        public string PublicId { get; set; }
    
    }
}
