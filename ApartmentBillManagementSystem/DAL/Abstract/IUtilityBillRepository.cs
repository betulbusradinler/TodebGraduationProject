using Models.Entities;
using System.Collections.Generic;

namespace DAL.Abstract
{
    public interface IUtilityBillRepository
    {
        public IEnumerable<UtilityBill> GetAll();

        public void Add(UtilityBill utilityBill);
        public void Update(UtilityBill utilityBill);
        public void Delete(UtilityBill utilityBill);
    }
}
