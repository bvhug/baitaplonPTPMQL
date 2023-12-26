using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nhom2.Models;

namespace MVC
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Nhom2.Models.BangGiaModel> BangGiaModel { get; set; } = default!;

        public DbSet<Nhom2.Models.GioiTinhModel> GioiTinhModel { get; set; } = default!;

        public DbSet<Nhom2.Models.XeModel> XeModel { get; set; } = default!;

        public DbSet<Nhom2.Models.VeXeModel> VeXeModel { get; set; } = default!;

        public DbSet<Nhom2.Models.TenXeModel> TenXeModel { get; set; } = default!;

        public DbSet<Nhom2.Models.TaiXeModel> TaiXeModel { get; set; } = default!;

        public DbSet<Nhom2.Models.NhanVienModel> NhanVienModel { get; set; } = default!;

        public DbSet<Nhom2.Models.KhachHangModel> KhachHangModel { get; set; } = default!;
    }
}
