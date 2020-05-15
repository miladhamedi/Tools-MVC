using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManualAuthenticationSample.Entities
{
    public partial class Users
    {
        public Users()
        {
            UserRoles = new HashSet<UserRoles>();
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(32)]
        public string UserName { get; set; }
        [Required]
        [StringLength(128)]
        public string Password { get; set; }
        [StringLength(64)]
        public string PasswordSalt { get; set; }
        public bool IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
