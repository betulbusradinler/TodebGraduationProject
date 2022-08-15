namespace DTO.User
{
    public class DeleteUserPasswordRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }     // User passwordün hangi kullanıcıya ait olduğunu bilmem lazım
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
    }
}
