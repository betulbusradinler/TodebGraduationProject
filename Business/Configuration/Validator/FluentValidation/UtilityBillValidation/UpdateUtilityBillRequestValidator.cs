using DTO.UtilityBill;
using FluentValidation;

namespace Business.Configuration.Validator.FluentValidation.UtilityBillValidation
{
    public class UpdateUtilityBillRequestValidator : AbstractValidator<UpdateUtilityBillRequest>
    {
        public UpdateUtilityBillRequestValidator()
        {
            RuleFor(x => x.UtilityBillNo).NotEmpty().WithMessage("Fatura numarasını boş bırakmayın");
            RuleFor(x => x.FlatId).NotEmpty().WithMessage("Faturaya ait bir daire numarası girin");
            RuleFor(x => x.BillNameId).NotEmpty().WithMessage("Fatura tipini girin");
        }
    }
}
