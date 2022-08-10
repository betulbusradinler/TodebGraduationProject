using DAL.Abstract;
using DAL.DbContexts;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.EF
{
    public class EFFlatRepository : IFlatRepository
    {
        private ApartmentMSDBContext _context;
        public EFFlatRepository(ApartmentMSDBContext context)
        {
            _context = context;
        }
        public void Insert(Flat flat)
        {
            _context.Flats.Add(flat);
            _context.SaveChanges();
        }

        public void Delete(Flat flat)
        {
            _context.Flats.Remove(flat);
            _context.SaveChanges();

        }

        public IEnumerable<Flat> GetAll()
        {
            // Tüm kullanıcıları döndü
            return _context.Flats.ToList();
        }

        public void Update(Flat flat)
        {
            _context.Flats.Update(flat);
            _context.SaveChanges();
        }
    }
}
