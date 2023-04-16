using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;

namespace CinemaManagement.Entities
{
    public class AppUser : FullAuditedEntity<long>, IEntity<long>
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime? DoB { get; set; }
        public bool Sex { get; set; }
        public string Email { get; set; }
    }
}
