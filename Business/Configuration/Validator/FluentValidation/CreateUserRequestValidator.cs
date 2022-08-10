using DTO.User;
using FluentValidation;

namespace Business.Configuration.Validator.FluentValidation
{
    public class CreateUserRequestValidator:AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            // Yeni bir kullanıcı eklenmeden önce yapılması gereken validation işlemleri
            RuleFor(x => x.No).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Email).EmailAddress().NotEmpty();
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Please specify a first name");
            //RuleFor(x => x.Password).NotEmpty();
            //RuleFor(x => x.Discount).NotEqual(0).When(x => x.HasDiscount);
            //RuleFor(x => x.Address).Length(20, 250);
            //RuleFor(x => x.Postcode).Must(BeAValidPostcode).WithMessage("Please specify a valid postcode");
        }
    }
}
