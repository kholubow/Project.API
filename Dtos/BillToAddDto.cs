using System.ComponentModel.DataAnnotations;

namespace Project.API.Dtos
{
    public class BillToAddDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Salesman { get; set; }  
        [Required]
        public string Buyer { get; set; } 
        [Required]
        public string ServiceName { get; set; } 
        [Required]
        public float Price { get; set; }  
        [Required]
        public string PaymentMethod { get; set; }   
    }
}
