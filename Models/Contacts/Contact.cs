using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_MVC.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Phai nhap {0}")]
        [Column(TypeName = "nvarchar")]
        [StringLength(50, ErrorMessage = "{0} phai nho hon {1} ky tu")]
        [Display(Name = "Ho ten")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Phai nhap {0}")]
        [Phone(ErrorMessage = "{0} khong dung dinh dang")]
        [StringLength(50)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Vui long nhap {0}")]
        [EmailAddress(ErrorMessage = "{0} ko dung dinh dang")]
        [StringLength(100)]
        public string Email { get; set; }

        public DateTime DateSent { get; set; }
        [Display(Name = "Noi dung")]
        public string Message { get; set; }
    }
}
