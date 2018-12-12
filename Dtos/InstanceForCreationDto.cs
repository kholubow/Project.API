using System;
using System.ComponentModel.DataAnnotations;

namespace Project.API.Dtos
{
    public class InstanceForCreationDto
    {
        [Required]
        public DateTime InstanceStart { get; set; }
        
        [Required]
        public DateTime InstanceEnd { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string TypeOfInstance { get; set; }
    }
}
