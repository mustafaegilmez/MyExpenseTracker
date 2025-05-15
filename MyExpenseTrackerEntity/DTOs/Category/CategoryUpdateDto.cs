using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MyExpenseTrackerEntity.Enums;

namespace MyExpenseTrackerEntity.DTOs.Category
{
    public class CategoryUpdateDto
    {
        [Required]
        public Guid Id { get; set; }

        [DisplayName("Kategori Adı")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [DisplayName("Tür")]
        [Required]
        public TransactionType Type { get; set; }

        [DisplayName("Varsayılan mı?")]
        public bool IsDefault { get; set; } = false;
    }
}