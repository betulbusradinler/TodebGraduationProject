using DAL.Abstract;
using DAL.DbContexts;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class FlatRepository : IFlatRepository
    {
        private GraduationProjectDbContext _context;
        public FlatRepository(GraduationProjectDbContext context)
        {
            this._context = context;
        }
        public void Add(Flat flat)
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
