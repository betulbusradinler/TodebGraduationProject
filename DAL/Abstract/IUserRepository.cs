using DAL.EFBase;
using Models.Entities;
using System.Collections.Generic;

namespace DAL.Abstract
{
    public interface IUserRepository : IEFBaseRepository<User>
    {
        // User ile ilgili veritabanında 4 temel işlemim olabilir. CRUD

    }
}
