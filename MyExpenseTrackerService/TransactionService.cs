using MyExpenseTrackerDal.Context;
using MyExpenseTrackerDal.Repositories.Base;
using MyExpenseTrackerEntity.Entities;

namespace MyExpenseTrackerService
{
    public class TransactionService : BaseCrudDal<Transaction>
    {
        public TransactionService(AppDbContext context) : base(context)
        {
        }

        public override IEnumerable<Transaction> GetAll()
        {
            return base.GetAll(null, new List<string> { "User", "Category" });
        }
    }
}