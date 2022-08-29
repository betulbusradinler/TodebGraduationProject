using DAL.Abstract;
using DAL.DbContexts;
using DAL.EFBase;
using Models.Entities;
using System.Linq;

namespace DAL.Concrete.EF
{
    public class EFUserPasswordRepository : EFBaseRepository<UserPassword, ApartmentMSDBContext>, IUserPasswordRepository
    {
        public EFUserPasswordRepository(ApartmentMSDBContext context) : base(context)
        {
        }

        public void UpdateUserPassword(UserPassword request)
        {
            var entity = Context.Users.Where(x => x.Id == request.Id).SingleOrDefault();
        }
    }
}
