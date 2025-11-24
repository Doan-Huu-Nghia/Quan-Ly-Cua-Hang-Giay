using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLCHgiay.Models;

[Table("PhanLoai")]
public partial class PhanLoai
{
    [Key]
    [Column("ID")]
    [StringLength(10)]
    public string Id { get; set; } = null!;

    [StringLength(50)]
    public string TenLoai { get; set; } = null!;

    public string? MoTa { get; set; }

    [InverseProperty("PhanLoai")]
    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
