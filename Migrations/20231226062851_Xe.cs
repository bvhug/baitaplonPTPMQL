using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nhom2.Migrations
{
    /// <inheritdoc />
    public partial class Xe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BangGiaModel",
                columns: table => new
                {
                    GiaID = table.Column<string>(type: "TEXT", nullable: false),
                    GiaVe = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BangGiaModel", x => x.GiaID);
                });

            migrationBuilder.CreateTable(
                name: "GioiTinhModel",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    TenGioiTinh = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioiTinhModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TenXeModel",
                columns: table => new
                {
                    XeID = table.Column<string>(type: "TEXT", nullable: false),
                    TenXeBienSo = table.Column<string>(name: "TenXe_BienSo", type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenXeModel", x => x.XeID);
                });

            migrationBuilder.CreateTable(
                name: "KhachHangModel",
                columns: table => new
                {
                    MaKhachHang = table.Column<string>(type: "TEXT", nullable: false),
                    TenKhachHang = table.Column<string>(type: "TEXT", nullable: false),
                    Ngaysinh = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenGioiTinh = table.Column<string>(type: "TEXT", nullable: true),
                    Diachi = table.Column<string>(type: "TEXT", nullable: true),
                    CMND = table.Column<string>(type: "TEXT", nullable: false),
                    SoDienThoai = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangModel", x => x.MaKhachHang);
                    table.ForeignKey(
                        name: "FK_KhachHangModel_GioiTinhModel_TenGioiTinh",
                        column: x => x.TenGioiTinh,
                        principalTable: "GioiTinhModel",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "NhanVienModel",
                columns: table => new
                {
                    MaNhanVien = table.Column<string>(type: "TEXT", nullable: false),
                    TenNhanVien = table.Column<string>(type: "TEXT", nullable: false),
                    Ngaysinh = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TenGioiTinh = table.Column<string>(type: "TEXT", nullable: true),
                    Diachi = table.Column<string>(type: "TEXT", nullable: true),
                    CMND = table.Column<string>(type: "TEXT", nullable: false),
                    SoDienThoai = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVienModel", x => x.MaNhanVien);
                    table.ForeignKey(
                        name: "FK_NhanVienModel_GioiTinhModel_TenGioiTinh",
                        column: x => x.TenGioiTinh,
                        principalTable: "GioiTinhModel",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TaiXeModel",
                columns: table => new
                {
                    MaTaiXe = table.Column<string>(type: "TEXT", nullable: false),
                    TenTaiXe = table.Column<string>(type: "TEXT", nullable: false),
                    Ngaysinh = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenGioiTinh = table.Column<string>(type: "TEXT", nullable: true),
                    Diachi = table.Column<string>(type: "TEXT", nullable: true),
                    CMND = table.Column<string>(type: "TEXT", nullable: false),
                    SoDienThoai = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiXeModel", x => x.MaTaiXe);
                    table.ForeignKey(
                        name: "FK_TaiXeModel_GioiTinhModel_TenGioiTinh",
                        column: x => x.TenGioiTinh,
                        principalTable: "GioiTinhModel",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "VeXeModel",
                columns: table => new
                {
                    MaVe = table.Column<string>(type: "TEXT", nullable: false),
                    TenVe = table.Column<string>(type: "TEXT", nullable: true),
                    TenXeBienSo = table.Column<string>(name: "TenXe_BienSo", type: "TEXT", nullable: true),
                    MaNhanVien = table.Column<string>(type: "TEXT", nullable: true),
                    MaKhachHang = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeXeModel", x => x.MaVe);
                    table.ForeignKey(
                        name: "FK_VeXeModel_KhachHangModel_MaKhachHang",
                        column: x => x.MaKhachHang,
                        principalTable: "KhachHangModel",
                        principalColumn: "MaKhachHang");
                    table.ForeignKey(
                        name: "FK_VeXeModel_NhanVienModel_MaNhanVien",
                        column: x => x.MaNhanVien,
                        principalTable: "NhanVienModel",
                        principalColumn: "MaNhanVien");
                    table.ForeignKey(
                        name: "FK_VeXeModel_TenXeModel_TenXe_BienSo",
                        column: x => x.TenXeBienSo,
                        principalTable: "TenXeModel",
                        principalColumn: "XeID");
                });

            migrationBuilder.CreateTable(
                name: "XeModel",
                columns: table => new
                {
                    MaXe = table.Column<string>(type: "TEXT", nullable: false),
                    TenCuaXe = table.Column<string>(type: "TEXT", nullable: true),
                    MaTaiXe = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XeModel", x => x.MaXe);
                    table.ForeignKey(
                        name: "FK_XeModel_TaiXeModel_MaTaiXe",
                        column: x => x.MaTaiXe,
                        principalTable: "TaiXeModel",
                        principalColumn: "MaTaiXe");
                    table.ForeignKey(
                        name: "FK_XeModel_TenXeModel_TenCuaXe",
                        column: x => x.TenCuaXe,
                        principalTable: "TenXeModel",
                        principalColumn: "XeID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_KhachHangModel_TenGioiTinh",
                table: "KhachHangModel",
                column: "TenGioiTinh");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVienModel_TenGioiTinh",
                table: "NhanVienModel",
                column: "TenGioiTinh");

            migrationBuilder.CreateIndex(
                name: "IX_TaiXeModel_TenGioiTinh",
                table: "TaiXeModel",
                column: "TenGioiTinh");

            migrationBuilder.CreateIndex(
                name: "IX_VeXeModel_MaKhachHang",
                table: "VeXeModel",
                column: "MaKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_VeXeModel_MaNhanVien",
                table: "VeXeModel",
                column: "MaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_VeXeModel_TenXe_BienSo",
                table: "VeXeModel",
                column: "TenXe_BienSo");

            migrationBuilder.CreateIndex(
                name: "IX_XeModel_MaTaiXe",
                table: "XeModel",
                column: "MaTaiXe");

            migrationBuilder.CreateIndex(
                name: "IX_XeModel_TenCuaXe",
                table: "XeModel",
                column: "TenCuaXe");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BangGiaModel");

            migrationBuilder.DropTable(
                name: "VeXeModel");

            migrationBuilder.DropTable(
                name: "XeModel");

            migrationBuilder.DropTable(
                name: "KhachHangModel");

            migrationBuilder.DropTable(
                name: "NhanVienModel");

            migrationBuilder.DropTable(
                name: "TaiXeModel");

            migrationBuilder.DropTable(
                name: "TenXeModel");

            migrationBuilder.DropTable(
                name: "GioiTinhModel");
        }
    }
}
