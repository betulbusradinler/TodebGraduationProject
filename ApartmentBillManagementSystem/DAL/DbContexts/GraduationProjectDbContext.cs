using DAL.Abstract;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DAL.DbContexts
{
    public  class GraduationProjectDbContext:DbContext
    { // Bu da bir dependency Injectiondır ama bunu .net core kendisi ayarlıyor.
        //private IConfiguration _configuration;
        //public SchoolDbContext(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}
        public DbSet<User> Users { get; set; }
        public DbSet<UserPassword> UsersPassswords { get; set; }
        //public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<UtilityBill> UtilityBills { get; set; }
        public DbSet<UtilityBillType> UtilityBillTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer("Server=ERENINPC\\SQLEXPRESS03;Database=UtilityManagementSystem;Trusted_Connection=True;"));
            // Yukarıda Magic String olarak verdiğimiz ifadeyi artık IConfiguring den alıcaz.

            //var connectionString = _configuration.GetConnectionString("MsConn");
            //base.OnConfiguring(optionsBuilder.UseSqlServer(connectionString));
        }
    }
}
//Migration modellerin arasıdaki bağlantıların saklanır
