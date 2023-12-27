using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nhom2.Migrations
{
    /// <inheritdoc />
    public partial class KhachHang : Migration
    {
        public object MaKhachHang { get; internal set; }
        public string TenKhachHang { get; internal set; }
        public string Ngaysinh { get; internal set; }
        public string GioiTinh { get; internal set; }
        public string Diachi { get; internal set; }
        public string CMND { get; internal set; }

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
