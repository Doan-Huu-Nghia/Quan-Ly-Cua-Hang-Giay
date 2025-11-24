using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLCHgiay.Models;

[Table("KhuyenMai")]
public partial class KhuyenMai
{
    [Key]
    [Column("ID")]
    [StringLength(10)]
    [DisplayName("Mã KM")]
    public string Id { get; set; } = null!;

    [Column("LoaiKM")]
    [StringLength(20)]
	[DisplayName("Loại KM")]
	public string LoaiKm { get; set; } = null!;

    [Column("GiaTriKM", TypeName = "decimal(10, 2)")]
	[DisplayName("Giá trị")]
	public decimal GiaTriKm { get; set; }

    [Column("DoiTuongKM")]
    [StringLength(20)]
	[DisplayName("Lớp KM")]
	public string DoiTuongKm { get; set; } = null!;

    [Column("DoiTuongID")]
    [StringLength(10)]
	[DisplayName("Đối tượng KM")]
	public string DoiTuongId { get; set; } = null!;

    [Column(TypeName = "datetime")]
	[DisplayName("Ngày bắt đầu")]
	public DateTime NgayBatDau { get; set; }

    [Column(TypeName = "datetime")]
	[DisplayName("Ngày kết thúc")]
	public DateTime NgayKetThuc { get; set; }
}
