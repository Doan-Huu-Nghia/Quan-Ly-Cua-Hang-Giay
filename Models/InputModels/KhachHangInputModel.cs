using System.ComponentModel.DataAnnotations;

namespace QLCHgiay.Models.InputModels
{
	public class KhachHangInputModel
	{
		[Required(ErrorMessage = "Số điện thoại là bắt buộc.")]
		[StringLength(10, MinimumLength = 10, ErrorMessage = "Số điện thoại phải có 10 ký tự.")]
		[RegularExpression(@"^\d{10}$", ErrorMessage = "Số điện thoại không hợp lệ.")]
		public string Sdt { get; set; } = null!;

		[Required(ErrorMessage = "Tên khách hàng là bắt buộc.")]
		[StringLength(100)]
		public string TenKhachHang { get; set; } = null!;

		[StringLength(12, MinimumLength = 12, ErrorMessage = "CCCD phải có 12 ký tự.")]
		[RegularExpression(@"^\d{12}$", ErrorMessage = "CCCD không hợp lệ.")]
		public string? Cccd { get; set; } = null!;

		[EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ.")]
		public string? Email { get; set; }

		[StringLength(200)]
		public string? DiaChi { get; set; }
	}
}
