using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLCHgiay.Models;

[Table("ThuongHieu")]
public partial class ThuongHieu
{
    [Key]
    [Column("ID")]
    [StringLength(10)]
    public string Id { get; set; } = null!;

    [StringLength(50)]
    public string TenThuongHieu { get; set; } = null!;

    public string? MoTa { get; set; }

    [InverseProperty("ThuongHieu")]
    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
