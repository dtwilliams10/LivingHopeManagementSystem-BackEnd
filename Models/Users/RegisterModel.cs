using System.ComponentModel.DataAnnotations;

namespace LHMSAPI.Models.Users
{
    public class RegisterModel
    {
        [Required]
        public string firstName {get; set;}

        [Required]
        public string lastName {get; set;}

        [Required]
        public string emailAddress {get; set;}

        [Required]
        public string username {get; set;}

        [Required]
        public string password {get; set;}
    }
}