using DAL.Abstract;
using DAL.DbContexts;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Concrete.EF
{
    public class EFUtilityBillRepository : IUtilityBillRepository
    {
        private ApartmentMSDBContext _context;
        public EFUtilityBillRepository(ApartmentMSDBContext context)
        {
            _context = context;
        }

        public void Insert(UtilityBill utilityBill)
        {
            _context.UtilityBills.Add(utilityBill);
            _context.SaveChanges();
        }

        public void Delete(UtilityBill utilityBill)
        {
            _context.UtilityBills.Remove(utilityBill);
            _context.SaveChanges();
        }

        public IEnumerable<UtilityBill> GetAll()
        {
            return _context.UtilityBills.ToList();
        }

        public void Update(UtilityBill utilityBill)
        {
            _context.UtilityBills.Update(utilityBill);
            _context.SaveChanges();
        }
    }
}
