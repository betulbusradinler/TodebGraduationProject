
using DTO.User;
using FluentValidation;

namespace Business.Configuration.Validator.FluentValidation
{
    public class DeleteUserRequestValidator : AbstractValidator<DeleteUserRequest>
    {
        public DeleteUserRequestValidator()
        {
            RuleFor(x => x.Id).Equal(x => x.Id).WithMessage("Böyle bir kullanıcı bulunamadı");
        }
    }
}
