using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLCHgiay.Models;

[Table("SanPham")]
public partial class SanPham
{
    [Key]
    [Column("ID")]
    [StringLength(10)]
    [DisplayName("Mã SP")]
    public string Id { get; set; } = null!;

    [Column("TenSP")]
    [StringLength(50)]
	[DisplayName("Tên SP")]
	public string TenSp { get; set; } = null!;

	[DisplayName("Kích cỡ")]
	public byte? KichCo { get; set; }

	[DisplayName("Màu sắc")]
	public string? MauSac { get; set; }

    [Column(TypeName = "decimal(10, 0)")]
	[DisplayName("Giá bán")]
	public decimal GiaBan { get; set; }

    [Column(TypeName = "decimal(10, 0)")]
	[DisplayName("Giá gốc")]
	public decimal GiaGoc { get; set; }

	[DisplayName("Trạng thái")]
	public bool TrangThai { get; set; }

	[DisplayName("Tồn kho")]
	public short TonKho { get; set; }

    [Column("PhanLoaiID")]
    [StringLength(10)]
	public string? PhanLoaiId { get; set; }

    [Column("ThuongHieuID")]
    [StringLength(10)]
	public string? ThuongHieuId { get; set; }

    [ForeignKey("PhanLoaiId")]
    [InverseProperty("SanPhams")]
	[DisplayName("Phân loại")]
	public virtual PhanLoai? PhanLoai { get; set; }

    [ForeignKey("ThuongHieuId")]
    [InverseProperty("SanPhams")]
	[DisplayName("Thương hiệu")]
	public virtual ThuongHieu? ThuongHieu { get; set; }
}
