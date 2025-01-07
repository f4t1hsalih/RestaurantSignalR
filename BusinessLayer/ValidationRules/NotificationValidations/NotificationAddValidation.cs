using DTOLayer.NotificationDto;
using FluentValidation;

namespace BusinessLayer.ValidationRules.NotificationValidations
{
    public class NotificationAddValidation : AbstractValidator<InsertNotificationDto>
    {
        public NotificationAddValidation()
        {
            // Type doğrulaması: Boş olamaz
            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Tür boş olamaz.");

            // Icon doğrulaması: Boş olamaz, geçerli bir URL formatında olmalı
            RuleFor(x => x.Icon)
                .NotEmpty().WithMessage("Simge boş olamaz.");

            // Description doğrulaması: Boş olamaz
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama boş olamaz.");
        }
    }
}
