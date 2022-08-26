using DTO.Flat;
using FluentValidation;
namespace Business.Configuration.Validator.FluentValidation.FlatValidation
{
    public class CreateFlatRequestValidator : AbstractValidator<CreateFlatRegisterRequest>
    {
        public CreateFlatRequestValidator()
        {
        }
    }
}
