using DAL.Abstract;
using DAL.DbContexts;
using Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Concrete
{
    //  Bu Katman verileri veritabanı operasyonlarına yönelikti.
    //  Yani veri tabanına gider verileri alır veya vermiş olduğum datayı kaydeder  
    public class UserRepository : IUserRepository
    {
        // Bu metodlarla ilgili operasyonlar burada yazılacak ancak bunun için VERİTABANI bağlantısına ihtiyacım var.
        // Kullanıcı ile ilgili işlemlerimde tüm crud metodları gerekli olduğu için hepsini ekledim.

        private GraduationProjectDbContext context;
        public UserRepository(GraduationProjectDbContext context)
        {
            this.context = context;
        }
        public void Add(User user)  // Veri tabanına kullanıcı kaydı ekliyor
        {
            context.Users.Add(user); //Gelen kullanıcıyı ekledim
            context.SaveChanges();   // Kaydın yapılması için SaveChanges metodunu unutmamalıyız.
        }

        public void Delete(User user)  // Veri tabanından kullanıcı kaydını sildim
        {
            context.Users.Remove(user); 
            context.SaveChanges();   
        }

        public IEnumerable<User> GetAll() // Veri tabanından kullanıcı tüm kayıtlarını getirir
        {
            // Tüm kullanıcıları döndü
            return context.Users.ToList();
        }
        public void Update(User user)  // Veri tabanından kullanıcı kaydını siler
        {

            context.Users.Update(user);
            context.SaveChanges();
        }
    }
}
