using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizletWeb.Team7.Models
{
    [Table("sanpham")]
    public partial class Sanpham
    {
        public Sanpham()
        {
            Hangtonkho = new HashSet<Hangtonkho>();
        }

        [Key]
        [Column("id_sanpham")]
        public int IdSanpham { get; set; }
        [Required]
        [Column("ten_sanpham")]
        [StringLength(50)]
        public string TenSanpham { get; set; }
        [Column("phan_loai")]
        [StringLength(25)]
        public string PhanLoai { get; set; }

        [InverseProperty("IdSanphamNavigation")]
        public virtual ICollection<Hangtonkho> Hangtonkho { get; set; }
    }
}
