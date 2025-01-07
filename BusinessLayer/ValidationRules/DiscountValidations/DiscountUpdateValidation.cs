using DTOLayer.DiscountDto;
using FluentValidation;

namespace BusinessLayer.ValidationRules.DiscountValidations
{
    public class DiscountUpdateValidation : AbstractValidator<UpdateDiscountDto>
    {
        public DiscountUpdateValidation()
        {
            // Title doğrulaması: Boş olamaz
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık boş olamaz.");

            // Amount doğrulaması: Geçerli bir sayısal değer olmalı
            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("Tutar boş olamaz.")
                .Matches(@"^\d+(\.\d{1,2})?$").WithMessage("Geçerli bir tutar giriniz (örneğin, 10.50).");

            // ImageUrl doğrulaması: Boş olamaz
            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Görsel URL'si boş olamaz.");
        }
    }
}
