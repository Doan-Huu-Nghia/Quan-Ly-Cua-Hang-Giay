using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLCHgiay.Models;

[Table("KhachHang")]
public partial class KhachHang
{
    [Key]
    [Column("SDT")]
    [StringLength(10)]
    public string Sdt { get; set; } = null!;

    [StringLength(50)]
    public string TenKhachHang { get; set; } = null!;

    [StringLength(50)]
    public string? Email { get; set; }

    [Column("CCCD")]
    [StringLength(12)]
    public string? Cccd { get; set; }

    public string? DiaChi { get; set; }

    [InverseProperty("KhachHangSdtNavigation")]
    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
}
