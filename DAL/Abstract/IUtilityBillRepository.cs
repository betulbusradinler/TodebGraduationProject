using Models.Entities;
using System.Collections.Generic;

namespace DAL.Abstract
{
    public interface IUtilityBillRepository
    {
        public IEnumerable<UtilityBill> GetAll();

        public void Insert(UtilityBill utilityBill);
        public void Update(UtilityBill utilityBill);
        public void Delete(UtilityBill utilityBill);
    }
}
