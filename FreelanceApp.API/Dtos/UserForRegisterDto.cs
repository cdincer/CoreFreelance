using System.ComponentModel.DataAnnotations;

namespace FreelanceApp.API.Dtos
{
    public class UserForRegisterDto
    {

        [Required]
        public string Username {get; set;}
        [Required]
        [StringLength(8,MinimumLength=4,ErrorMessage="Min Length 4 ,Max Length 8 for password length")]
        public string Password {get; set;}
    }
}