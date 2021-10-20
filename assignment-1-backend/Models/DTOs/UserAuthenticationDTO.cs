using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace assignment_1_backend.Models.DTOs
{
    public class UserAuthenticationDTO
    {
        [Required(ErrorMessage = "Email is required.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string Password { get; set; }
    }
}
