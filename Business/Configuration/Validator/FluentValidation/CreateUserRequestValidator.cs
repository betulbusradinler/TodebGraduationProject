using DTO.User;
using FluentValidation;

namespace Business.Configuration.Validator.FluentValidation
{
    public class CreateUserRequestValidator:AbstractValidator<CreateUserRegisterRequest>
    {
        public CreateUserRequestValidator()
        {
            // Yeni bir kullanıcı eklenmeden önce yapılması gereken validation işlemleri

            RuleFor(x => x.Email).NotEqual(x => x.Email).WithMessage("Böyle bir kullanıcı mevcut");
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Email).EmailAddress().NotEmpty().WithMessage("Lütfen e-mailinizi doğru formatta giriniz");
            RuleFor(x => x.Phone).NotEmpty();
            RuleFor(x => x.UserPassword).NotEmpty();
            RuleFor(x => x.ConfirmPassword).NotEmpty();
            //RuleFor(x => x.Discount).NotEqual(0).When(x => x.HasDiscount);
            //RuleFor(x => x.Address).Length(20, 250);
            //RuleFor(x => x.Postcode).Must(BeAValidPostcode).WithMessage("Please specify a valid postcode");
        }
    }
}
