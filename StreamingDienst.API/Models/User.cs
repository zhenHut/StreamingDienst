using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreamingDienst.API.Models
{
    [Table("users")]
   public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("email")]
        public string Email {  get; set; } = string .Empty;
        [Column("password_hash")]
        public string PasswordHash { get; set; } = string.Empty;

    }
}
