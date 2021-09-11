
using System.ComponentModel.DataAnnotations;


namespace PMAY.Dto.Users
{
   public class UserLoginDto
    {
        [Required]
        //[EmailAddress]
        public string UserId { get; set; }
        [Required]
        public string Password { get; set; }
        public bool Isremember { get; set; }

    }
}
