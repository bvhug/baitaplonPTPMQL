using System.ComponentModel.DataAnnotations;
namespace Nhom2.Models
{
    public class BangGiaModel
    {
        [Key]
         [Display (Name = "ID")]
        public string? GiaID {get; set;}
        [Display (Name = "Giá vé")]
        public string? GiaVe {get; set;}
    }
}