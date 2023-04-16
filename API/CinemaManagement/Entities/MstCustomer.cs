using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaManagement.Entities
{
    public class MstCustomer : FullAuditedEntity<long>, IEntity<long>
    {
        [Required]
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public DateTime? DoB { get; set; }
        public bool Sex { get; set; }
        [Required]
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
