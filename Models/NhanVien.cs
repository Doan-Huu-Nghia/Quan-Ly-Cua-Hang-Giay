using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLCHgiay.Models
{
	[Table("NhanVien")]
	public class NhanVien
	{
		[Key]
		[Required]
		[Column("ID", TypeName = "nvarchar")]
		[StringLength(10)]
		public  string Id { get; set; }

		[Column("TenNV")]
		[StringLength(50)]
		[DisplayName("Tên nhân viên")]
		public string TenNV { get; set; }

		[Column("CCCD")]
		[StringLength(12)]
		public string CCCD { get; set; }

		[Column("SDT")]
		[StringLength(10)]
		[DisplayName("Số điện thoại")]
		public string SDT { get; set; }

		[Column("DiaChi", TypeName = "nvarchar(max)")]
		[DisplayName("Địa chỉ")]
		public string DiaChi { get; set; }

		[Column("NgayBatDau", TypeName = "datetime")]
		[DisplayName("Ngày bắt đầu")]
		public DateTime? NgayBatDau { get; set; }

		public ApplicationUser? TaiKhoan { get; set; }

		public ICollection<BangCong> BangCongs { get; set; }
		public ICollection<HoaDon> HoaDons { get; set; }
		public ICollection<PhieuNhap> PhieuNhaps { get; set; }
	}
}
