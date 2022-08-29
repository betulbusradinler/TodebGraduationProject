using DTO.User;
using FluentValidation;

namespace Business.Configuration.Validator.FluentValidation.UserValidation
{
    public class UpdateUserPasswordRequestValidator : AbstractValidator<UpdateUserPasswordRegisterRequest>
    {
        public UpdateUserPasswordRequestValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("Lütfen kullanıcı Id sini girin");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Lütfen şifre girin");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Lütfen şifrenizi tekrar girin");
        }
    }
}
