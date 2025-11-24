using System.ComponentModel.DataAnnotations;

namespace QLCHgiay.Models.InputModels
{
	public class PhieuNhapInputModel
	{
		[Required(ErrorMessage = "Ngày lập không được để trống.")]
		public DateTime NgayTao { get; set; } = DateTime.Now;

		[Required(ErrorMessage = "Vui lòng chọn Nhà cung cấp.")]
		public string NhaCungCapId { get; set; }

		public decimal ThanhTien { get; set; }

		// Số tiền đã trả (Nếu bạn có trường DaTra)
		public decimal DaTra { get; set; } = 0;

		// Trường TrangThai (Nếu có trong Entity Phiếu Nhập)
		public bool TrangThai { get; set; } = true;

		// Thuộc tính QUAN TRỌNG: Danh sách chi tiết
		[MinLength(1, ErrorMessage = "Phiếu nhập phải có ít nhất một sản phẩm.")]
		public List<ChiTietPhieuNhapInputModel> ChiTiets { get; set; } = new List<ChiTietPhieuNhapInputModel>();

	}
}
