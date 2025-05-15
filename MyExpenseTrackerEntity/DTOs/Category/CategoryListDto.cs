using MyExpenseTrackerEntity.Enums;

namespace MyExpenseTrackerEntity.DTOs.Category
{
    public class CategoryListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TransactionType Type { get; set; }
        public bool IsDefault { get; set; }
    }
}