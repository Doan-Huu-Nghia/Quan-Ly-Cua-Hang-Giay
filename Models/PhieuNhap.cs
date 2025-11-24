using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLCHgiay.Models;

[Table("PhieuNhap")]
public partial class PhieuNhap
{
    [Key]
    [Column("ID")]
    [StringLength(10)]
    [DisplayName("Mã phiếu")]
    public string Id { get; set; } = null!;

    [Column(TypeName = "datetime")]
	[DisplayName("Ngày tạo")]
	public DateTime NgayTao { get; set; }

	[DisplayName("Trạng thái")]
	public bool TrangThai { get; set; }

    [Column(TypeName = "decimal(10, 0)")]
	[DisplayName("Thành tiền")]
	[DisplayFormat(DataFormatString = "{0:N0}")]
	public decimal ThanhTien { get; set; }

    [Column(TypeName = "decimal(10, 0)")]
	[DisplayName("Đã trả")]
	public decimal DaTra { get; set; }

    [Column("NhanVienID")]
    [StringLength(10)]
    public string NhanVienId { get; set; } = null!;

    [Column("NhaCungCapID")]
    [StringLength(10)]
    public string NhaCungCapId { get; set; } = null!;

    [ForeignKey("NhaCungCapId")]
    [InverseProperty("PhieuNhaps")]
	[DisplayName("Nhà cung cấp")]
	public virtual NhaCungCap NhaCungCap { get; set; } = null!;

	[ForeignKey("NhanVienId")]
	[InverseProperty("PhieuNhaps")]
	[DisplayName("Nhân viên lập")]
	public virtual NhanVien NhanVien { get; set; } = null!;

    [NotMapped]
    public virtual ICollection<ChiTietPhieuNhap>? ChiTietPhieuNhaps { get; set; } = new List<ChiTietPhieuNhap>();
}
