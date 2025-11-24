using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QLCHgiay.Models;

namespace QLCHgiay.Data
{
	public class SeedData
	{
		public static async Task Seeding(IServiceProvider serviceProvider)
		{
			var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
			var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
			var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();

			string[] roleNames = { "Admin", "Sales", "Warehouse" };
			foreach (var roleName in roleNames)
			{
				if (!await roleManager.RoleExistsAsync(roleName))
				{
					await roleManager.CreateAsync(new IdentityRole(roleName));
				}
			}
			if (await dbContext.NhanViens.FirstOrDefaultAsync(n => n.Id == "NV0000") == null)
			{
				var adminNhanVien = new NhanVien { Id = "NV0000", 
												   TenNV = "Đoàn Hữu Nghĩa",
												   CCCD = "000000000000",
												   SDT = "0852579710",
												   DiaChi = "An Giang",
												   NgayBatDau = DateTime.Today};
				await dbContext.NhanViens.AddAsync(adminNhanVien);
				await dbContext.SaveChangesAsync();

				
			}
			if (await userManager.FindByEmailAsync("admin@gmail.com") == null)
			{
				var adminUser = new ApplicationUser
				{
					UserName = "admin@gmail.com",
					Email = "admin@gmail.com",
					EmailConfirmed = true,
					NhanVienId = "NV0000"
				};

				var result = await userManager.CreateAsync(adminUser, "Admin123");
				if (result.Succeeded)
				{
					await userManager.AddToRoleAsync(adminUser, "Admin");
				}
				else
				{
					// === ĐOẠN CODE SỬA: LẤY LỖI RA ===
					var errors = result.Errors.Select(e => e.Description);
					var errorString = string.Join("\n", errors);

					// Nếu bạn đang dùng ILogger, bạn có thể log lỗi:
					// logger.LogError("Lỗi tạo Admin: {0}", errorString);

					// Hoặc nếu bạn muốn dừng chương trình để dễ debug (Chỉ dùng trong Dev)
					throw new Exception("Lỗi tạo tài khoản Admin:\n" + errorString);
					// =================================
				}
			}
		}
	}
}
