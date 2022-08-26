using DAL.Abstract;
using DAL.DbContexts;
using DAL.EFBase;
using Models.Entities;

namespace DAL.Concrete.EF
{
    public class EFChatRepository : EFBaseRepository<Chat, ApartmentMSDBContext>, IChatRepository
    {
        public EFChatRepository(ApartmentMSDBContext context) : base(context)
        {
        }
    }
}
