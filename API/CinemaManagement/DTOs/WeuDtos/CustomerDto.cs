using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaManagement.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime? DoB { get; set; }
        public bool Sex { get; set; }
        public string Email { get; set; }
    }
}
