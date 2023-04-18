using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaManagement.DTOs.WeuDtos
{
    public class CustomerEditDto
    {
        public string name { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public IFormFile image { get; set; }
    }
}
