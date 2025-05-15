using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyExpenseTrackerEntity.DTOs.User
{
    public class UserCreateDto
    {
        [DisplayName("Adı")]
        [Required]
        public string FirstName { get; set; }

        [DisplayName("Soyadı")]
        [Required]
        public string LastName { get; set; }

        [DisplayName("E-posta")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Şifre")]
        [Required]
        public string Password { get; set; }

        
    }
}