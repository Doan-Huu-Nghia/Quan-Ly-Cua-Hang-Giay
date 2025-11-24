using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLCHgiay.Models;

[Keyless]
[Table("ChiTietPhieuNhap")]
public partial class ChiTietPhieuNhap
{
    [Column("PhieuNhapID")]
    [StringLength(10)]
    public string? PhieuNhapId { get; set; }

    [Column("SanPhamID")]
    [StringLength(10)]
    public string? SanPhamId { get; set; }

    public short? SoLuong { get; set; }

    [Column(TypeName = "decimal(10, 0)")]
	[DisplayFormat(DataFormatString = "{0:N0}")]
	public decimal? DonGia { get; set; }

    [Column(TypeName = "decimal(10, 0)")]
	[DisplayFormat(DataFormatString = "{0:N0}")]
	public decimal? Tong { get; set; }

    [ForeignKey("PhieuNhapId")]
    public virtual PhieuNhap? PhieuNhap { get; set; }

    [ForeignKey("SanPhamId")]
    public virtual SanPham? SanPham { get; set; }
}
