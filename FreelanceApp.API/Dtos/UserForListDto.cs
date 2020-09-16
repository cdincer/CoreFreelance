using System;
using System.Collections.Generic;
using FreelanceApp.API.Models;

namespace FreelanceApp.API.Dtos
{
    public class UserForListDto
    {
         public int Id {get; set;}
        public string Username {get; set;}
  
        public int Experience {get; set;} 
        public DateTime Created {get; set;}
        public DateTime LastActive {get; set;}
        //Type of Teammates they are looking for
        public string Country {get; set;}
        public string City {get; set;}
        public string  PhotoUrl{get;set;}
    }
}