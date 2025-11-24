using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLCHgiay.Migrations
{
    /// <inheritdoc />
    public partial class AddChiTietPhieuNhapPK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietPhieuNhap_PhieuNhap",
                table: "ChiTietPhieuNhap");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietPhieuNhap_SanPham",
                table: "ChiTietPhieuNhap");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietPhieuNhap_PhieuNhapID",
                table: "ChiTietPhieuNhap");

            migrationBuilder.AlterColumn<string>(
                name: "SanPhamID",
                table: "ChiTietPhieuNhap",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhieuNhapID",
                table: "ChiTietPhieuNhap",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietPhieuNhap",
                table: "ChiTietPhieuNhap",
                columns: new[] { "PhieuNhapID", "SanPhamID" });

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietPhieuNhap_PhieuNhap",
                table: "ChiTietPhieuNhap",
                column: "PhieuNhapID",
                principalTable: "PhieuNhap",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietPhieuNhap_SanPham",
                table: "ChiTietPhieuNhap",
                column: "SanPhamID",
                principalTable: "SanPham",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietPhieuNhap_PhieuNhap",
                table: "ChiTietPhieuNhap");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietPhieuNhap_SanPham",
                table: "ChiTietPhieuNhap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietPhieuNhap",
                table: "ChiTietPhieuNhap");

            migrationBuilder.AlterColumn<string>(
                name: "SanPhamID",
                table: "ChiTietPhieuNhap",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "PhieuNhapID",
                table: "ChiTietPhieuNhap",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhap_PhieuNhapID",
                table: "ChiTietPhieuNhap",
                column: "PhieuNhapID");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietPhieuNhap_PhieuNhap",
                table: "ChiTietPhieuNhap",
                column: "PhieuNhapID",
                principalTable: "PhieuNhap",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietPhieuNhap_SanPham",
                table: "ChiTietPhieuNhap",
                column: "SanPhamID",
                principalTable: "SanPham",
                principalColumn: "ID");
        }
    }
}
