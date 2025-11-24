using System.ComponentModel.DataAnnotations;

namespace QLCHgiay.Models.InputModels
{
	public class SanPhamInputModel
	{
		[Required(ErrorMessage = "Tên sản phẩm không được để trống.")]
		[StringLength(255, ErrorMessage = "Tên sản phẩm không được vượt quá 255 ký tự.")]
		public string TenSanPham { get; set; }

		[Required(ErrorMessage = "Vui lòng chọn Phân loại.")]
		public string PhanLoaiId { get; set; }

		[Required(ErrorMessage = "Vui lòng chọn Thương hiệu.")]
		public string ThuongHieuId { get; set; }

		[Required(ErrorMessage = "Vui lòng chọn Kích cỡ.")]
		public byte? KichCo { get; set; }

		[Required(ErrorMessage = "Vui lòng chọn Màu sắc.")]
		public string MauSac { get; set; }

		[Required(ErrorMessage = "Giá bán không được để trống.")]
		[Range(0.01, 999999999.99, ErrorMessage = "Giá bán phải là số dương.")]
		public decimal GiaBan { get; set; }

		[Required(ErrorMessage = "Giá vốn không được để trống.")]
		[Range(0.01, 999999999.99, ErrorMessage = "Giá vốn phải là số dương.")]
		public decimal GiaGoc { get; set; }

		[Range(0, 999999, ErrorMessage = "Số lượng tồn kho không hợp lệ.")]
		public short TonKho { get; set; } = 0;

		public bool TrangThai { get; set; } = false;
	}
}
