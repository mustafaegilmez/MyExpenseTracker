using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;
using MyExpenseTrackerEntity.Base;
namespace MyExpenseTrackerEntity.Entities
{
    public class User : BaseEntity
    {
        [DisplayName("Adı")]
        [Required]
        public string FirstName { get; set; }

        [DisplayName("Soyadı")]
        [Required]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        [DisplayName("E-posta")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Şifre")]
        [Required]
        public string Password { get; set; }

        [DisplayName("Kullanıcı Rol")]
        public string Role { get; set; } = "User"; 

        public ICollection<Category> Categories { get; set; }  // Kullanıcının kategorileri
        public ICollection<Transaction> Transactions { get; set; }
    }

}
