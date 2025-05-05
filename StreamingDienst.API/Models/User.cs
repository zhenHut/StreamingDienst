using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

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
