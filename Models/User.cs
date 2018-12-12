using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Project.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string UserSurname { get; set; }
        public string Position { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; } 
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public User()
        {
            Photos = new Collection<Photo>();
        }
         
    }
}
