
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMAY.Dto.Users
{
   public class UserRegistrationDto
    {
        [Required]
    //   [Phone]
        public string UserId { get; set; }
        [Required]
        public string Password { get; set; }

      //  [Required]
        public string Email { get; set; }
        //[Required]
        public string PhoneNo { get; set; }
        //[Required]
        //public RoleEnum RoleId { get; set; }
    }
}
