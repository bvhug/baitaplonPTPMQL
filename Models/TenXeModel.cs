using System.ComponentModel.DataAnnotations;
namespace Nhom2.Models
{
    public class TenXeModel
    {
        [Key]
        public string? XeID {get; set;}
        [Display (Name = "Tên xe - Biển số")]
        public string? TenXe_BienSo {get; set;}
    }
}