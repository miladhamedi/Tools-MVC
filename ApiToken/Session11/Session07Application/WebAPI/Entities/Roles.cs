using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Entities
{
    public partial class Roles
    {
        public Roles()
        {
            RolePermissions = new HashSet<RolePermissions>();
            UserRoles = new HashSet<UserRoles>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(128)]
        public string RoleName { get; set; }
        public bool IsActive { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<RolePermissions> RolePermissions { get; set; }
        [InverseProperty("Role")]
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
