using DAL.Abstract;
using DAL.DbContexts;
using DAL.EFBase;
using Models.Entities;

namespace DAL.Concrete.EF
{
    public class EFOneTimeBillingForAllFlatsRepository : EFBaseRepository<UtilityBill, ApartmentMSDBContext>, IOneTimeBillingForAllFlatsRepository
    {
        public EFOneTimeBillingForAllFlatsRepository(ApartmentMSDBContext context) : base(context)
        {
        }
    }
}
