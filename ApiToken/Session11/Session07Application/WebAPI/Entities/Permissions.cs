using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Entities
{
    public partial class Permissions
    {
        public Permissions()
        {
            RolePermissions = new HashSet<RolePermissions>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(256)]
        public string AreaName { get; set; }
        [StringLength(256)]
        public string AreaCaption { get; set; }
        [StringLength(256)]
        public string ControllerName { get; set; }
        [StringLength(256)]
        public string ControllerCaption { get; set; }
        [StringLength(256)]
        public string ActionName { get; set; }
        [StringLength(256)]
        public string ActionCaption { get; set; }
        public byte? ActionType { get; set; }

        [InverseProperty("Permission")]
        public virtual ICollection<RolePermissions> RolePermissions { get; set; }
    }
}
