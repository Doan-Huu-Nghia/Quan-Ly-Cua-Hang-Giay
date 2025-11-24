using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLCHgiay.Models;

[Table("BangCong")]
public partial class BangCong
{
    [Key]
    [Column("ID")]
    [StringLength(10)]
    public string Id { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime GioVao { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime GioRa { get; set; }

    public bool TrangThai { get; set; }

    [Column("NhanVienID")]
    [StringLength(10)]
    public string NhanVienId { get; set; } = null!;

	[ForeignKey("NhanVienId")]
	[InverseProperty("BangCongs")]
	public virtual NhanVien NhanVien { get; set; } = null!;
}
