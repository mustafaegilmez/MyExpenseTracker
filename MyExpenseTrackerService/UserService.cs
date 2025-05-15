using MyExpenseTrackerDal.Context;
using MyExpenseTrackerDal.Repositories.Base;
using MyExpenseTrackerEntity.Entities;

namespace MyExpenseTrackerService
{
    public class UserService : BaseCrudDal<User>
    {
        public UserService(AppDbContext context) : base(context)
        {
        }
    }
}