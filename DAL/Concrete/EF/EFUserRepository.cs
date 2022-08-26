using DAL.Abstract;
using DAL.DbContexts;
using DAL.EFBase;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System.Linq;

namespace DAL.Concrete.EF
{
    //  Bu Katman verileri veritabanı operasyonlarına yönelikti.
    //  Yani veri tabanına gider verileri alır veya vermiş olduğum datayı kaydeder  
    public class EFUserRepository : EFBaseRepository<User, ApartmentMSDBContext>, IUserRepository
    {
        public EFUserRepository(ApartmentMSDBContext context) : base(context)
        {
        }

        public User GetUserWithPassword(string email)
        {
            // Passwordü dahil ettik
            return Context.Users
               .Include(x => x.Password)
               .FirstOrDefault(x => x.Email == email);
        }
    }
}
