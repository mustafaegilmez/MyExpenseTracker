using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyExpenseTrackerEntity.DTOs.User
{
    public class UserUpdateDto
    {
        [Required]
        public Guid Id { get; set; }

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

        [DisplayName("Kullanıcı Rol")]
        public string Role { get; set; }
    }

}