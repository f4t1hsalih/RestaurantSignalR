using DTOLayer.AboutDto;
using FluentValidation;

namespace BusinessLayer.ValidationRules.AboutValidations
{
    public class AboutUpdateValidation : AbstractValidator<UpdateAboutDto>
    {
        public AboutUpdateValidation()
        {
            // ImageUrl doğrulaması: Boş olamaz
            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Görsel URL'si boş olamaz.");

            // Title doğrulaması: Minimum 3 karakter, boş olamaz
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık boş olamaz.")
                .MinimumLength(3).WithMessage("Başlık en az 3 karakter uzunluğunda olmalıdır.");

            // Description doğrulaması: Minimum 10 karakter, boş olamaz
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama boş olamaz.")
                .MinimumLength(10).WithMessage("Açıklama en az 10 karakter uzunluğunda olmalıdır.");
        }
    }
}
