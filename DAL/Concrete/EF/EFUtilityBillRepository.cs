using DAL.Abstract;
using DAL.DbContexts;
using DAL.EFBase;
using Models.Entities;

namespace DAL.Concrete.EF
{
    public class EFUtilityBillRepository : EFBaseRepository<UtilityBill, ApartmentMSDBContext>, IUtilityBillRepository
    {
        public EFUtilityBillRepository(ApartmentMSDBContext context) : base(context)
        {
   
        }

    }
}
