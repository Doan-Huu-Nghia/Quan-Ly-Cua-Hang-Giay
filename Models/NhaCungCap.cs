using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLCHgiay.Models;

[Table("NhaCungCap")]
public partial class NhaCungCap
{
    [Key]
    [Column("ID")]
    [StringLength(10)]
    public string Id { get; set; } = null!;

    [StringLength(50)]
    public string TenNhaCungCap { get; set; } = null!;

    [Column("SDT")]
    [StringLength(12)]
    public string Sdt { get; set; } = null!;

    [StringLength(50)]
    public string Email { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    [InverseProperty("NhaCungCap")]
    public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; } = new List<PhieuNhap>();
}
