using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizletWeb.Team7.Models
{
    [Table("memberinfo")]
    public partial class Memberinfo
    {
        [Key]
        [Column("userid")]
        public int Userid { get; set; }
        [Required]
        [Column("username")]
        [StringLength(50)]
        public string Username { get; set; }
        [Required]
        [Column("userpassword")]
        [StringLength(50)]
        public string Userpassword { get; set; }
        [Column("fullname")]
        [StringLength(100)]
        public string Fullname { get; set; }
    }
}
