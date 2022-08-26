using DAL.EFBase;
using Models.Entities;

namespace DAL.Abstract
{
    public interface IUtilityBillRepository : IEFBaseRepository<UtilityBill>
    {
        // Benim burada yapmak istediğim şey  yani fatura tablosu kayıt edilirken
        // böyle bir daire var mı kontrol etmek
        // onu da daireno üzerinden kontrol etmem gerek
    }
}
