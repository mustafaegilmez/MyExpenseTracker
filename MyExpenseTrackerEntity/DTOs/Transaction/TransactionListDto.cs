namespace MyExpenseTrackerEntity.DTOs.Transaction
{
    public class TransactionListDto
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string UserFullName { get; set; }
        public string CategoryName { get; set; }
    }

}