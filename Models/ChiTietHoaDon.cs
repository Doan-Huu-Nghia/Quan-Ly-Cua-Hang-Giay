using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLCHgiay.Models;

[Keyless]
[Table("ChiTietHoaDon")]
public partial class ChiTietHoaDon
{
    [Column("HoaDonID")]
    [StringLength(10)]
    public string HoaDonId { get; set; } = null!;

    [Column("SanPhamID")]
    [StringLength(10)]
    public string SanPhamId { get; set; } = null!;

    [Column("KhuyenMaiID")]
    [StringLength(10)]
    public string? KhuyenMaiId { get; set; }

    public short SoLuong { get; set; }

    [Column(TypeName = "decimal(10, 0)")]
    public decimal DonGiaBan { get; set; }

    [Column("TienTruocKM", TypeName = "decimal(10, 0)")]
    public decimal TienTruocKm { get; set; }

    [Column(TypeName = "decimal(10, 0)")]
    public decimal TienChietKhau { get; set; }

    [Column(TypeName = "decimal(10, 0)")]
    public decimal ThanhTien { get; set; }

    [ForeignKey("HoaDonId")]
    public virtual HoaDon HoaDon { get; set; } = null!;

    [ForeignKey("KhuyenMaiId")]
    public virtual KhuyenMai? KhuyenMai { get; set; }

    [ForeignKey("SanPhamId")]
    public virtual SanPham SanPham { get; set; } = null!;
}
