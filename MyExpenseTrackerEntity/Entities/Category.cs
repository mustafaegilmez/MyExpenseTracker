using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MyExpenseTrackerEntity.Base;
using MyExpenseTrackerEntity.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyExpenseTrackerEntity.Entities
{
    public class Category : BaseEntity
    {
        [DisplayName("Kategori Adı")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [DisplayName("Tür")]
        [Required]
        public TransactionType Type { get; set; }

        [DisplayName("Varsayılan mı?")]
        public bool IsDefault { get; set; } = false;

        [DisplayName("Kullanıcı")]
        [Required]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public ICollection<Transaction>? Transactions { get; set; }
    }

}