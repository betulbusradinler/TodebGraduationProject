using Business.Configuration.Response;
using DTO.User;

namespace Business.Abstract
{
    public interface IUserPasswordService
    {
        CommandResponse UpdateUserPassword(UpdateUserPasswordRegisterRequest request);

    }
}
