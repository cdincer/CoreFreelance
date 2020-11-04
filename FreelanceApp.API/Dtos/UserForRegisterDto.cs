using System.ComponentModel.DataAnnotations;
using System;
namespace FreelanceApp.API.Dtos
{
    public class UserForRegisterDto
    {

        [Required]
        public string Username {get; set;}
        [Required]
        [StringLength(8,MinimumLength=4,ErrorMessage="Min Length 4 ,Max Length 8 for password length")]
        public string Password {get; set;}

        [Required]
        public string City {get; set;}

        [Required]
        public string Country {get; set;}

        [Required]
        public int Experience {get; set;}

        public DateTime Created {get; set;}
        public DateTime LastActive {get; set;}

        public UserForRegisterDto()
        {
            Created = DateTime.Now;
            LastActive = DateTime.Now;

        }

    }
}