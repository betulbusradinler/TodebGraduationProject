using Models.Entities;

namespace DTO.User
{
    public class UpdateUserPasswordRegisterRequest
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
