using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Entities
{
    public partial class UserTokens
    {
        [Key]
        public int Id { get; set; }
        public Guid UserId { get; set; }
        [Required]
        [StringLength(64)]
        public string RefreshToken { get; set; }
        public bool IsValid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ExpireDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
    }
}
