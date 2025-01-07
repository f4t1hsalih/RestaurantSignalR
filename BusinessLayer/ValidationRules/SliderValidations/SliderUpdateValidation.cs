using DTOLayer.SliderDto;
using FluentValidation;

namespace BusinessLayer.ValidationRules.SliderValidations
{
    public class SliderUpdateValidation : AbstractValidator<UpdateSliderDto>
    {
        public SliderUpdateValidation()
        {
            // Title1 doğrulaması: Boş olamaz
            RuleFor(x => x.Title1)
                .NotEmpty().WithMessage("Başlık 1 boş olamaz.");

            // Title2 doğrulaması: Boş olamaz
            RuleFor(x => x.Title2)
                .NotEmpty().WithMessage("Başlık 2 boş olamaz.");

            // Title3 doğrulaması: Boş olamaz
            RuleFor(x => x.Title3)
                .NotEmpty().WithMessage("Başlık 3 boş olamaz.");

            // Description1 doğrulaması: Boş olamaz
            RuleFor(x => x.Description1)
                .NotEmpty().WithMessage("Açıklama 1 boş olamaz.");

            // Description2 doğrulaması: Boş olamaz
            RuleFor(x => x.Description2)
                .NotEmpty().WithMessage("Açıklama 2 boş olamaz.");

            // Description3 doğrulaması: Boş olamaz
            RuleFor(x => x.Description3)
                .NotEmpty().WithMessage("Açıklama 3 boş olamaz.");
        }
    }
}
