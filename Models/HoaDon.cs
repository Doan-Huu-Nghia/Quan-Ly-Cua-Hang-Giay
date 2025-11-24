using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLCHgiay.Models;

[Table("HoaDon")]
public partial class HoaDon
{
    [Key]
    [Column("ID")]
    [StringLength(10)]
    [DisplayName("Mã hóa đơn")]
    public string Id { get; set; } = null!;

    [Column(TypeName = "datetime")]
	[DisplayName("Ngày lập")]
	public DateTime NgayTao { get; set; }

	[DisplayName("Trạng thái")]
	public bool TrangThai { get; set; }

    [Column("TongTienTruocKM", TypeName = "decimal(10, 0)")]
	[DisplayName("Tiền trước khuyến mãi")]
	[DisplayFormat(DataFormatString = "{0:N0}")]
	public decimal TongTienTruocKm { get; set; }

    [Column(TypeName = "decimal(10, 0)")]
	[DisplayName("Tiền chiết khấu")]
	[DisplayFormat(DataFormatString = "{0:N0}")]
	public decimal TongTienChietKhau { get; set; }

    [Column(TypeName = "decimal(10, 0)")]
	[DisplayName("Thành tiền")]
	[DisplayFormat(DataFormatString = "{0:N0}")]
	public decimal ThanhTien { get; set; }

    [Column("NhanVienID")]
    [StringLength(10)]
    public string NhanVienId { get; set; } = null!;

    [Column("KhachHangSDT")]
    [StringLength(10)]
    public string? KhachHangSdt { get; set; } = null!;

    [ForeignKey("KhachHangSdt")]
    [InverseProperty("HoaDons")]
	[DisplayName("SĐT khách hàng")]
	public virtual KhachHang? KhachHangSdtNavigation { get; set; } = null!;

    [ForeignKey("NhanVienId")]
	[InverseProperty("HoaDons")]
	[DisplayName("Nhân viên lập")]
	public virtual NhanVien NhanVien { get; set; } = null!;

	[NotMapped]
	public virtual ICollection<ChiTietHoaDon>? ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();
}
