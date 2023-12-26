using System.ComponentModel.DataAnnotations;

namespace Nhom2.Models
{
    public class GioiTinhModel
    {
        public string? ID {get; set;}
        [Display (Name = "Giới tính")]
        public string? TenGioiTinh {get; set;}
    }
}