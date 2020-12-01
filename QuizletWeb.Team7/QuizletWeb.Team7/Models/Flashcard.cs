using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizletWeb.Team7.Models
{
    [Table("flashcard")]
    public partial class Flashcard
    {
        [Key]
        [Column("flashcardid")]
        [StringLength(6)]
        public string Flashcardid { get; set; }
        [Required]
        [Column("classid")]
        [StringLength(6)]
        public string Classid { get; set; }
        [Column("flashcardtitle")]
        [StringLength(100)]
        public string Flashcardtitle { get; set; }
        [Column("descriptioncard")]
        [StringLength(250)]
        public string Descriptioncard { get; set; }

        [ForeignKey(nameof(Classid))]
        [InverseProperty(nameof(Classcard.Flashcard))]
        public virtual Classcard Class { get; set; }
    }
}
