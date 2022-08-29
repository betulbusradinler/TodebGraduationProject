using DTO.Chat;
using FluentValidation;

namespace Business.Configuration.Validator.FluentValidation.ChatValidation
{
    public class UpdateChatRequestValidator : AbstractValidator<UpdateChatRequest>
    {
        public UpdateChatRequestValidator()
        {
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Mesaj içeriğini boş bırakmayın");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Mesaj içeriğini boş bırakmayın");
            RuleFor(x => x.ReciverMail).NotEmpty().WithMessage("Göndereceğiniz mail adresini girin");
            RuleFor(x => x.SenderMail).NotEmpty().WithMessage("Kendi mail adresinizi girin");
        }
    }
}
