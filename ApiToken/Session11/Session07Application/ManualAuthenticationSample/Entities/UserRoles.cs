using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManualAuthenticationSample.Entities
{
    public partial class UserRoles
    {
        [Key]
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int RoleId { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty(nameof(Roles.UserRoles))]
        public virtual Roles Role { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Users.UserRoles))]
        public virtual Users User { get; set; }
    }
}
