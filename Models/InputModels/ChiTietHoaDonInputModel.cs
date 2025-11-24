using System.ComponentModel.DataAnnotations;

namespace QLCHgiay.Models.InputModels
{
	public class ChiTietHoaDonInputModel
	{
		[Required(ErrorMessage = "Vui lòng chọn Sản phẩm.")]
		public string SanPhamId { get; set; }

		[Required(ErrorMessage = "Số lượng không được để trống.")]
		[Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0.")]
		public short SoLuong { get; set; }

		public decimal GiaBan { get; set; }
		public string? KhuyenMaiId { get; set; } = null;
	}
}
