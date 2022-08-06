using Models.Entities;
using System.Collections.Generic;

namespace DAL.Abstract
{
    public interface IUserRepository
    {
        // User ile ilgili veritabanında 4 temel işlemim olabilir. CRUD

        public IEnumerable<User> GetAll();

        public void Add(User user);
        public void Update(User user);  
        public void Delete(User user);
    }
}
