using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyExpenseTrackerEntity.DTOs.Transaction
{
    public class TransactionCreateDto
    {
        [DisplayName("Tutar")]
        [Required]
        public decimal Amount { get; set; }

        [DisplayName("Açıklama")]
        [MaxLength(300)]
        public string Description { get; set; }

        [DisplayName("Tarih")]
        [Required]
        public DateTime Date { get; set; } = DateTime.Now;

        [DisplayName("Kategori")]
        [Required]
        public Guid CategoryId { get; set; }
    }

}