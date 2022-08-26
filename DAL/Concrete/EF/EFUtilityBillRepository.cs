using DAL.Abstract;
using DAL.DbContexts;
using DAL.EFBase;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Concrete.EF
{
    public class EFUtilityBillRepository : EFBaseRepository<UtilityBill, ApartmentMSDBContext>, IUtilityBillRepository
    {
        private readonly IFlatRepository _flatRepository;
        public EFUtilityBillRepository(ApartmentMSDBContext context) : base(context)
        {
   
        }

    }
}
