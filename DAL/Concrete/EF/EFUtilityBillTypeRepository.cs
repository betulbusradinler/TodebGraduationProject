using DAL.Abstract;
using DAL.DbContexts;
using DAL.EFBase;
using Models.Entities;

namespace DAL.Concrete.EF
{
    public class EFUtilityBillTypeRepository : EFBaseRepository<UtilityBillType, ApartmentMSDBContext>, IUtilityBillTypeRepository

    {
        public EFUtilityBillTypeRepository(ApartmentMSDBContext context) : base(context)
        {
        }
    }
}
