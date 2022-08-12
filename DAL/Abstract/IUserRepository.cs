using DAL.EFBase;
using Models.Entities;
using System.Collections.Generic;

namespace DAL.Abstract
{
    public interface IUserRepository : IEFBaseRepository<User>
    {
        // Interface default access modifier public
        // Get metodu ile user ı çağırdığımızda user ın userPassword bilgisini vermeyecek ama örneğin biz Login olacağız
        // Login olacağımız zaman bunu  aşağıdaki metodu kullanarak alabiliriz.
        User GetUserWithPassword(string email);
    }
}
