using DTO.Flat;
using FluentValidation;
namespace Business.Configuration.Validator.FluentValidation.FlatValidation
{
    public class CreateFlatRequestValidator : AbstractValidator<CreateFlatRegisterRequest>
    {
        public CreateFlatRequestValidator()
        {
            RuleFor(x => x.No).NotEmpty().WithMessage("Lütfen Daire numarasını girin");
            RuleFor(x => x.FloorNo).NotEmpty().WithMessage("Lütfen Kat numarasını girin");
            RuleFor(x => x.Block).NotEmpty().WithMessage("Lütfen hangi blok olduğunu girin");
            RuleFor(x => x.State).NotEmpty().WithMessage("Lütfen dairenin dolu mu boş mu olduğunu giriniz");
        }
    }
}
