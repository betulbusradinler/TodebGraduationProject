using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models.Entities;

namespace DAL.DbContexts
{
    public class ApartmentMSDBContext : DbContext
    {
        private IConfiguration _configuration;
        public ApartmentMSDBContext(IConfiguration configuration)
        {

            _configuration = configuration;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserPassword> UsersPassswords { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<UtilityBill> UtilityBills { get; set; }
        public DbSet<UtilityBillType> UtilityBillTypes { get; set; }
        public DbSet<Chat> Chats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("MsComm");
            base.OnConfiguring(optionsBuilder.UseSqlServer(connectionString));
        }
        // Uniq olan alanları ekledim
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>() 
                .HasIndex(u => u.Email)
                .IsUnique();

            builder.Entity<UtilityBillType>()
             .HasIndex(u => u.Name)
             .IsUnique();

            builder.Entity<User>()
            .HasIndex(u => u.LicensePlate)
            .IsUnique();

            builder.Entity<Flat>()
            .HasIndex(u => u.No)
            .IsUnique();

            builder.Entity<UtilityBill>()
            .HasIndex(u => u.UtilityBillNo)
            .IsUnique();
        }
    }
}

