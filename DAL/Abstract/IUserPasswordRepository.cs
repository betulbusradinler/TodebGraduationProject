using DAL.EFBase;
using DTO.User;
using Models.Entities;

namespace DAL.Abstract
{
    public interface IUserPasswordRepository : IEFBaseRepository<UserPassword>
    {
        void UpdateUserPassword(UserPassword request);
    }
}
