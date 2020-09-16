using System;
using System.Collections.Generic;
using FreelanceApp.API.Models;

namespace FreelanceApp.API.Dtos
{
    public class UserForDetailedDto
    {
         public int Id {get; set;}
        public string Username {get; set;}

        public int Experience {get; set;} 
        public DateTime Created {get; set;}
        public DateTime LastActive {get; set;}
        public string PersonalSummary {get; set;}
        public string LookingFor {get; set;}
         public string Country {get; set;}
        public string City {get; set;}
        public string  PhotoUrl{get;set;}

        public ICollection<PhotosForDetailedDto> Photos{get;set;}

    }
}