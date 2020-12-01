using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizletWeb.Team7.Models
{
    [Table("hangtonkho")]
    public partial class Hangtonkho
    {
        [Key]
        [Column("id_hangtonkho")]
        public int IdHangtonkho { get; set; }
        [Column("id_sanpham")]
        public int IdSanpham { get; set; }
        [Column("soluong")]
        public int? Soluong { get; set; }
        [Column("luong_toithieu")]
        public int? LuongToithieu { get; set; }
        [Column("luong_toida")]
        public int? LuongToida { get; set; }

        [ForeignKey(nameof(IdSanpham))]
        [InverseProperty(nameof(Sanpham.Hangtonkho))]
        public virtual Sanpham IdSanphamNavigation { get; set; }
    }
}
