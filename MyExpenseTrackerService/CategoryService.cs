using MyExpenseTrackerDal.Context;
using MyExpenseTrackerDal.Repositories.Base;
using MyExpenseTrackerEntity.Entities;

namespace MyExpenseTrackerService
{
    public class CategoryService : BaseCrudDal<Category>
    {
        public CategoryService(AppDbContext context) : base(context)
        {
        }
    }
}