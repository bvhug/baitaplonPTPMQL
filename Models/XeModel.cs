using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Nhom2.Models
{
    public class XeModel
    {
        [Key]
        [Display (Name = "Mã xe")]
        [Required(ErrorMessage ="Mã xe không được bỏ trống")]
        public string? MaXe {get; set;} 
        [Display (Name = "Tên xe")]
        public string? TenCuaXe {get; set;}
        [ForeignKey ("TenCuaXe")]
        public TenXeModel? TenXe {get; set;}
        [Display (Name = "Mã tài xế")]
        public string? MaTaiXe {get; set;}
        [ForeignKey ("MaTaiXe")]
        public TaiXeModel? TaiXe {get; set;}
    }
}