using DTO.User;
using FluentValidation;

namespace Business.Configuration.Validator.FluentValidation.UserValidation
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRegisterRequest>
    {
        public CreateUserRequestValidator()
        {
            // Yeni bir kullanıcı eklenmeden önce yapılması gereken validation işlemleri
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Lütfen soyadınızı girin");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen adınızı girin");
            RuleFor(x => x.Email).EmailAddress().NotEmpty().WithMessage("Lütfen e-mailinizi doğru formatta girin");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Lütfen telefon numaranızı girin");
        }
    }
}
