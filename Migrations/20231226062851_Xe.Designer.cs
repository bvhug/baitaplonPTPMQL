﻿// <auto-generated />
using System;
using MVC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Nhom2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231226062851_Xe")]
    partial class Xe
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("Nhom2.Models.BangGiaModel", b =>
                {
                    b.Property<string>("GiaID")
                        .HasColumnType("TEXT");

                    b.Property<string>("GiaVe")
                        .HasColumnType("TEXT");

                    b.HasKey("GiaID");

                    b.ToTable("BangGiaModel");
                });

            modelBuilder.Entity("Nhom2.Models.GioiTinhModel", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenGioiTinh")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("GioiTinhModel");
                });

            modelBuilder.Entity("Nhom2.Models.KhachHangModel", b =>
                {
                    b.Property<string>("MaKhachHang")
                        .HasColumnType("TEXT");

                    b.Property<string>("CMND")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Diachi")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Ngaysinh")
                        .HasColumnType("TEXT");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenGioiTinh")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenKhachHang")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaKhachHang");

                    b.HasIndex("TenGioiTinh");

                    b.ToTable("KhachHangModel");
                });

            modelBuilder.Entity("Nhom2.Models.NhanVienModel", b =>
                {
                    b.Property<string>("MaNhanVien")
                        .HasColumnType("TEXT");

                    b.Property<string>("CMND")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Diachi")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Ngaysinh")
                        .HasColumnType("TEXT");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenGioiTinh")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenNhanVien")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaNhanVien");

                    b.HasIndex("TenGioiTinh");

                    b.ToTable("NhanVienModel");
                });

            modelBuilder.Entity("Nhom2.Models.TaiXeModel", b =>
                {
                    b.Property<string>("MaTaiXe")
                        .HasColumnType("TEXT");

                    b.Property<string>("CMND")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Diachi")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Ngaysinh")
                        .HasColumnType("TEXT");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenGioiTinh")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenTaiXe")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaTaiXe");

                    b.HasIndex("TenGioiTinh");

                    b.ToTable("TaiXeModel");
                });

            modelBuilder.Entity("Nhom2.Models.TenXeModel", b =>
                {
                    b.Property<string>("XeID")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenXe_BienSo")
                        .HasColumnType("TEXT");

                    b.HasKey("XeID");

                    b.ToTable("TenXeModel");
                });

            modelBuilder.Entity("Nhom2.Models.VeXeModel", b =>
                {
                    b.Property<string>("MaVe")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaKhachHang")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaNhanVien")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenVe")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenXe_BienSo")
                        .HasColumnType("TEXT");

                    b.HasKey("MaVe");

                    b.HasIndex("MaKhachHang");

                    b.HasIndex("MaNhanVien");

                    b.HasIndex("TenXe_BienSo");

                    b.ToTable("VeXeModel");
                });

            modelBuilder.Entity("Nhom2.Models.XeModel", b =>
                {
                    b.Property<string>("MaXe")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaTaiXe")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenCuaXe")
                        .HasColumnType("TEXT");

                    b.HasKey("MaXe");

                    b.HasIndex("MaTaiXe");

                    b.HasIndex("TenCuaXe");

                    b.ToTable("XeModel");
                });

            modelBuilder.Entity("Nhom2.Models.KhachHangModel", b =>
                {
                    b.HasOne("Nhom2.Models.GioiTinhModel", "GioiTinh")
                        .WithMany()
                        .HasForeignKey("TenGioiTinh");

                    b.Navigation("GioiTinh");
                });

            modelBuilder.Entity("Nhom2.Models.NhanVienModel", b =>
                {
                    b.HasOne("Nhom2.Models.GioiTinhModel", "GioiTinh")
                        .WithMany()
                        .HasForeignKey("TenGioiTinh");

                    b.Navigation("GioiTinh");
                });

            modelBuilder.Entity("Nhom2.Models.TaiXeModel", b =>
                {
                    b.HasOne("Nhom2.Models.GioiTinhModel", "GioiTinh")
                        .WithMany()
                        .HasForeignKey("TenGioiTinh");

                    b.Navigation("GioiTinh");
                });

            modelBuilder.Entity("Nhom2.Models.VeXeModel", b =>
                {
                    b.HasOne("Nhom2.Models.KhachHangModel", "KhachHang")
                        .WithMany()
                        .HasForeignKey("MaKhachHang");

                    b.HasOne("Nhom2.Models.NhanVienModel", "NhanVien")
                        .WithMany()
                        .HasForeignKey("MaNhanVien");

                    b.HasOne("Nhom2.Models.TenXeModel", "TenXe")
                        .WithMany()
                        .HasForeignKey("TenXe_BienSo");

                    b.Navigation("KhachHang");

                    b.Navigation("NhanVien");

                    b.Navigation("TenXe");
                });

            modelBuilder.Entity("Nhom2.Models.XeModel", b =>
                {
                    b.HasOne("Nhom2.Models.TaiXeModel", "TaiXe")
                        .WithMany()
                        .HasForeignKey("MaTaiXe");

                    b.HasOne("Nhom2.Models.TenXeModel", "TenXe")
                        .WithMany()
                        .HasForeignKey("TenCuaXe");

                    b.Navigation("TaiXe");

                    b.Navigation("TenXe");
                });
#pragma warning restore 612, 618
        }
    }
}
