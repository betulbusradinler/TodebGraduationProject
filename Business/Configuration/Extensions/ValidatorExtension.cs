using FluentValidation;
using System.Linq;

namespace Business.Configuration.Extensions
{
    public static class ValidatorExtension
    {
        // Yapılan validation işlemler sonucunda her gelen requestin response'unda aynı hata kodunu tekrarlamamak için static bir method oluşturuldu.
        public static void ThrowIfException(this FluentValidation.Results.ValidationResult validationResult)
        {
            if (validationResult.IsValid)
                return;

            var message = string.Join(',', validationResult.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(message);
        }
    }
}
