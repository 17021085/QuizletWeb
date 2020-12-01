using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizletWeb.Team7.Models
{
    [Table("classcard")]
    public partial class Classcard
    {
        public Classcard()
        {
            Flashcard = new HashSet<Flashcard>();
        }

        [Key]
        [Column("classid")]
        [StringLength(6)]
        public string Classid { get; set; }
        [Column("classname")]
        [StringLength(100)]
        public string Classname { get; set; }
        [Column("detail")]
        [StringLength(100)]
        public string Detail { get; set; }

        [InverseProperty("Class")]
        public virtual ICollection<Flashcard> Flashcard { get; set; }
    }
}
