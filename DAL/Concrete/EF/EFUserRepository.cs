using DAL.Abstract;
using DAL.DbContexts;
using DAL.EFBase;
using Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Concrete.EF
{
    //  Bu Katman verileri veritabanı operasyonlarına yönelikti.
    //  Yani veri tabanına gider verileri alır veya vermiş olduğum datayı kaydeder  
    public class EFUserRepository : EFBaseRepository<User,ApartmentMSDBContext>, IUserRepository
    {
        // Bu metodlarla ilgili operasyonlar burada yazılacak ancak bunun için VERİTABANI bağlantısına ihtiyacım var.
        // Kullanıcı ile ilgili işlemlerimde tüm crud metodları gerekli olduğu için hepsini ekledim.
        


        //public void Insert(User user)  // Veri tabanına kullanıcı kaydı ekliyor
        //{
        //    _context.Users.Add(user); //Gelen kullanıcıyı ekledim
        //    _context.SaveChanges();   // Kaydın yapılması için SaveChanges metodunu unutmamalıyız.
        //}

        //public void Delete(User user)  // Veri tabanından kullanıcı kaydını sildim
        //{
        //    _context.Users.Remove(user);
        //    _context.SaveChanges();
        //}

        //public IEnumerable<User> GetAll() // Veri tabanından kullanıcı tüm kayıtlarını getirir
        //{
        //    // Tüm kullanıcıları döndü
        //    return _context.Users.ToList();
        //}
        //public void Update(User user)  // Veri tabanından kullanıcı kaydını siler
        //{

        //    _context.Users.Update(user);
        //    _context.SaveChanges();
        //}
        //// Update de kayıt var mı yok mu onun kontrolünü yapmak daha sağlam
        //public User Get(int Id)
        //{
        //    return _context.Users.FirstOrDefault(x => x.Id == Id);
        //}
    }
}
