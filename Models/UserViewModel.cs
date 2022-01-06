using System.ComponentModel.DataAnnotations;

namespace API_CRUD_User.Models
{
    public class UserViewModel
    {
        [Key]
        [Required]
        [Display(Name ="fullName")]
        public string FullName { get; set; }

        [Required]
        [Display (Name = "address")]
        public string Address { get; set; }

        [Required]
        [Display (Name = "birthDate")]
        public string BirthDate { get; set; }

        [Required]
        [Display (Name = "sex")]
        public string Sex { get; set; }

        [Required]
        [Display (Name = "photo")]
        public string Photo { get; set; }
    }
}
