using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLCHgiay.Models
{
	public class ApplicationUser : IdentityUser
	{
		[Required]
		[Column("NhanVienId")]
		[StringLength(10)]
		public string NhanVienId { get; set; }

		// Navigation Property bắt buộc
		[ForeignKey("NhanVienId")]
		public NhanVien NhanVien { get; set; }
	}
}
