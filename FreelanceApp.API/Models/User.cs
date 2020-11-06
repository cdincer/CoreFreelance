using System;
using System.Collections.Generic;
using FreelanceApp.API.Models;


namespace FreelanceApp.API.Models
{
    public class User
    {
        public int Id {get; set;}
        public string Username {get; set;}
        public byte[] PasswordHash {get; set;}
        public byte[] PasswordSalt {get; set;}
        public string Country {get; set;}
        public int Experience {get; set;} 
        public DateTime Created {get; set;}
        public DateTime LastActive {get; set;}
        public string PersonalSummary {get; set;}
        //Type of Teammates they are looking for
        public string LookingFor {get; set;}
        public string City {get; set;}
        //Their portfolio photos/screenshots
        public ICollection<Photo> Photos{get;set;}
        public ICollection<Like> Likers {get; set;}
        public ICollection<Like> Likees {get; set;}


    }
}