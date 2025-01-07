using DTOLayer.SocialMediaDto;
using FluentValidation;

namespace BusinessLayer.ValidationRules.SocialMediaValidations
{
    public class SocialMediaAddValidation : AbstractValidator<InsertSocialMediaDto>
    {
        public SocialMediaAddValidation()
        {
            // Title doğrulaması: Boş olamaz
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık boş olamaz.");

            // Url doğrulaması: Boş olamaz, geçerli bir URL formatında olmalı
            RuleFor(x => x.Url)
                .NotEmpty().WithMessage("URL boş olamaz.");

            // Icon doğrulaması: Boş olamaz
            RuleFor(x => x.Icon)
                .NotEmpty().WithMessage("Simge boş olamaz.");
        }
    }
}
