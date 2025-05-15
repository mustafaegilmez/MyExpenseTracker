using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyExpenseTrackerEntity.Base
{
    public class BaseEntity : IBaseEntity
    {
        [Key]
        public virtual Guid Id { get; set; }

        [DisplayName("Oluşturma Tarihi")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [DisplayName("Güncelleme Tarihi")]
        public DateTime? UpdatedDate { get; set; }
    }

}