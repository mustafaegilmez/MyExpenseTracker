using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyExpenseTrackerEntity.Base;

namespace MyExpenseTrackerEntity.Entities
{
    public class Transaction : BaseEntity
    {
        [DisplayName("Tutar")]
        [Required]
        [Range(typeof(decimal), "0.01", "9999999999999", ErrorMessage = "Tutar 0'dan büyük olmalıdır.")]
        public decimal Amount { get; set; }

        [DisplayName("Açıklama")]
        [MaxLength(300)]
        public string Description { get; set; }

        [DisplayName("Tarih")]
        [Required]
        public DateTime Date { get; set; }

        [DisplayName("Kullanıcı")]
        [Required]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [DisplayName("Kategori")]
        [Required]
        public Guid CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
    }

}