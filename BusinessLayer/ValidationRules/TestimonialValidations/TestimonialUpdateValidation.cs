using DTOLayer.TestimonialDto;
using FluentValidation;

namespace BusinessLayer.ValidationRules.TestimonialValidations
{
    public class TestimonialUpdateValidation : AbstractValidator<UpdateTestimonialDto>
    {
        public TestimonialUpdateValidation()
        {
            // Name doğrulaması: Boş olamaz
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("İsim boş olamaz.");

            // Title doğrulaması: Boş olamaz
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık boş olamaz.");

            // Comment doğrulaması: Boş olamaz
            RuleFor(x => x.Comment)
                .NotEmpty().WithMessage("Yorum boş olamaz.");

            // ImageUrl doğrulaması: Boş olamaz
            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Görsel URL'si boş olamaz.");
        }
    }
}
