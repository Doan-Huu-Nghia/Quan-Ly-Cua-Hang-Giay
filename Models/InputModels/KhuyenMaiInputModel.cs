using System.ComponentModel.DataAnnotations;

namespace QLCHgiay.Models.InputModels
{
	public class KhuyenMaiInputModel
	{
		public string? Id { get; set; }

		[Required(ErrorMessage = "Loại khuyến mãi là bắt buộc.")]
		[StringLength(20)]
		public string LoaiKm { get; set; } = null!;

		[Required(ErrorMessage = "Giá trị khuyến mãi là bắt buộc.")]
		[Range(0.01, 1000000000.00, ErrorMessage = "Giá trị phải lớn hơn 0.")]
		public decimal GiaTriKm { get; set; }

		[Required(ErrorMessage = "Đối tượng áp dụng là bắt buộc.")]
		[StringLength(20)]
		public string DoiTuongKm { get; set; } = null!;

		[Required(ErrorMessage = "ID đối tượng là bắt buộc.")]
		[StringLength(10)]
		public string DoiTuongId { get; set; } = null!;

		[Required(ErrorMessage = "Ngày bắt đầu là bắt buộc.")]
		[DataType(DataType.Date)]
		public DateTime NgayBatDau { get; set; }

		[Required(ErrorMessage = "Ngày kết thúc là bắt buộc.")]
		[DataType(DataType.Date)]
		public DateTime NgayKetThuc { get; set; }
	}
}
