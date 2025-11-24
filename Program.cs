using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QLCHgiay.Configurations;
using QLCHgiay.Data;
using QLCHgiay.Models;
using static QLCHgiay.Configurations.AppOptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
	options.SignIn.RequireConfirmedAccount = false;
	// Tùy chọn: Cấu hình yêu cầu mật khẩu
	options.Password.RequireDigit = true;
	options.Password.RequireLowercase = true;
	options.Password.RequireUppercase = true;
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequiredLength = 6;
})
	.AddEntityFrameworkStores<ApplicationDbContext>() // Sử dụng DbContext tùy chỉnh của bạn
	.AddDefaultUI()
	.AddDefaultTokenProviders();

builder.Services.AddAuthorization(options =>
{
	// Quản lý: Truy cập tất cả (Chỉ Admin)
	options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));

	// Bán hàng: Quản lý Hóa đơn, Khách hàng (Admin hoặc Sales)
	options.AddPolicy("RequireSalesOrAdmin", policy => policy.RequireRole("Admin", "Sales"));

	// Kho hàng: Quản lý Sản phẩm, Phiếu nhập (Admin hoặc Warehouse)
	options.AddPolicy("RequireWarehouseOrAdmin", policy => policy.RequireRole("Admin", "Warehouse"));
});
builder.Services.AddAuthentication();

builder.Services.Configure<AppOptions>(
	builder.Configuration.GetSection(AppOptions.AppSettings));

builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	try
	{
		// Yêu cầu khởi tạo dữ liệu
		// Đảm bảo class DbInitializer và hàm SeedData tồn tại và đúng namespace
		await SeedData.Seeding(services);
	}
	catch (Exception ex)
	{
		var logger = services.GetRequiredService<ILogger<Program>>();
		logger.LogError(ex, "An error occurred during database seeding.");
	}
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
