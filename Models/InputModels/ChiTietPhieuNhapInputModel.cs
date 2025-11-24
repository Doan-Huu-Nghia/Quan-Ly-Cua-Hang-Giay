using System.ComponentModel.DataAnnotations;

namespace QLCHgiay.Models.InputModels
{
	public class ChiTietPhieuNhapInputModel
	{
		[Required(ErrorMessage = "Vui lòng chọn Sản phẩm.")]
		public string SanPhamId { get; set; }

		[Required(ErrorMessage = "Giá nhập không được để trống.")]
		[Range(0.01, double.MaxValue, ErrorMessage = "Giá nhập phải lớn hơn 0.")]
		public decimal GiaNhap { get; set; }

		// Số lượng nhập kho
		[Required(ErrorMessage = "Số lượng không được để trống.")]
		[Range(1, short.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0.")]
		public short SoLuong { get; set; }
	}
}
