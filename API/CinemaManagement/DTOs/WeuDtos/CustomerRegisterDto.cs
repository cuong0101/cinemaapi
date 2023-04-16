using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaManagement.DTOs
{
    public class CustomerRegisterDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string repassword { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        public DateTime? DoB { get; set; }
        public bool Sex { get; set; }
    }
}
