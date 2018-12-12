using System;

namespace Project.API.Models
{
    public class Instance
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime InstanceStart { get; set; }
        public DateTime InstanceEnd { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string UserSurname { get; set; }
        public string Position { get; set; }
        public string TypeOfInstance { get; set; }
    }
}
