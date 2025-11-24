using System.ComponentModel.DataAnnotations;

namespace QLCHgiay.Models.InputModels
{
	public class HoaDonInputModel
	{
		[Required(ErrorMessage = "Ngày lập không được để trống.")]
		public DateTime NgayLap { get; set; } = DateTime.Now;

		[StringLength(10, MinimumLength = 10, ErrorMessage = "SĐT phải có 10 ký tự.")]
		public string? KhachHangSdt { get; set; }

		public bool TrangThai { get; set; } = true;

		[MinLength(1, ErrorMessage = "Hóa đơn phải có ít nhất một sản phẩm.")]
		public List<ChiTietHoaDonInputModel> ChiTiets { get; set; } = new List<ChiTietHoaDonInputModel>();
	}
}
