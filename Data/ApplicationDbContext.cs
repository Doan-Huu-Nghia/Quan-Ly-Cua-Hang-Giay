using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QLCHgiay.Models;
using System;
using System.Collections.Generic;

namespace QLCHgiay.Data;

public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BangCong> BangCongs { get; set; }

    public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

    public virtual DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<KhuyenMai> KhuyenMais { get; set; }

    public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }

    public virtual DbSet<PhanLoai> PhanLoais { get; set; }

    public virtual DbSet<PhieuNhap> PhieuNhaps { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<ThuongHieu> ThuongHieus { get; set; }

	public virtual DbSet<NhanVien> NhanViens { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=KIOU5647\\KIOU;Initial Catalog=giay; Integrated Security = True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<ApplicationUser>().ToTable("TaiKhoan");
		modelBuilder.Entity<IdentityRole>().ToTable("QuyenHan");

		modelBuilder.Entity<ApplicationUser>()
		    .HasOne(tk => tk.NhanVien)
		    .WithOne(nv => nv.TaiKhoan)
		    .HasForeignKey<ApplicationUser>(tk => tk.NhanVienId)
		    .OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<ChiTietHoaDon>(entity =>
        {
			entity.HasKey(cthd => new { cthd.HoaDonId, cthd.SanPhamId });

			entity.HasOne(d => d.HoaDon).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietHoaDon_HoaDon");

            entity.HasOne(d => d.KhuyenMai).WithMany().HasConstraintName("FK_ChiTietHoaDon_KhuyenMai");

            entity.HasOne(d => d.SanPham).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietHoaDon_SanPham");
        });

        modelBuilder.Entity<ChiTietPhieuNhap>(entity =>
        {
			entity.HasKey(ctpn => new { ctpn.PhieuNhapId, ctpn.SanPhamId });

			entity.HasOne(d => d.PhieuNhap).WithMany().HasConstraintName("FK_ChiTietPhieuNhap_PhieuNhap");

            entity.HasOne(d => d.SanPham).WithMany().HasConstraintName("FK_ChiTietPhieuNhap_SanPham");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasOne(d => d.KhachHangSdtNavigation).WithMany(p => p.HoaDons)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HoaDon_KhachHang");
			entity.HasOne(d => d.NhanVien).WithMany(p => p.HoaDons)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_HoaDon_NhanVien");
		});

        modelBuilder.Entity<PhanLoai>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PhanLoai");
        });

        modelBuilder.Entity<PhieuNhap>(entity =>
        {
            entity.HasOne(d => d.NhaCungCap).WithMany(p => p.PhieuNhaps)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PhieuNhap_NhaCungCap");
			entity.HasOne(d => d.NhanVien).WithMany(p => p.PhieuNhaps)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_PhieuNhap_NhanVien");
		});

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasOne(d => d.PhanLoai).WithMany(p => p.SanPhams).HasConstraintName("FK_SanPham_PhanLoai");

            entity.HasOne(d => d.ThuongHieu).WithMany(p => p.SanPhams).HasConstraintName("FK_SanPham_ThuongHieu");
        });

        modelBuilder.Entity<ThuongHieu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ThuongHieu");
        });

		modelBuilder.Entity<BangCong>(entity =>
		{
			entity.HasOne(d => d.NhanVien)
				.WithMany(p => p.BangCongs)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_BangCong_NhanVien");
		});

		OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
