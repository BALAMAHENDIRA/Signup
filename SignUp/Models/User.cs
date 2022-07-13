using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SignUp.Models
{
    public partial class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage ="This field is required")]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public DateTime? Dob { get; set; }
    }
}
