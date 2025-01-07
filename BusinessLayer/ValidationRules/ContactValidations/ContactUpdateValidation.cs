using DTOLayer.ContactDto;
using FluentValidation;

namespace BusinessLayer.ValidationRules.ContactValidations
{
    public class ContactUpdateValidation : AbstractValidator<UpdateContactDto>
    {
        public ContactUpdateValidation()
        {
            // Location doğrulaması: Boş olamaz
            RuleFor(x => x.Location)
                .NotEmpty().WithMessage("Konum boş olamaz.");

            // Email doğrulaması: Geçerli bir e-posta adresi olmalı
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

            // PhoneNumber doğrulaması: Telefon numarası geçerli formatta olmalı
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarası boş olamaz.")
                .Matches(@"^\+?\d{10,15}$").WithMessage("Telefon numarası geçerli formatta olmalıdır.");

            // FooterTitle doğrulaması: Boş olamaz
            RuleFor(x => x.FooterTitle)
                .NotEmpty().WithMessage("Footer başlığı boş olamaz.");

            // FooterDescription doğrulaması: En az 10 karakter uzunluğunda olmalı
            RuleFor(x => x.FooterDescription)
                .NotEmpty().WithMessage("Footer açıklaması boş olamaz.")
                .MinimumLength(10).WithMessage("Footer açıklaması en az 10 karakter uzunluğunda olmalıdır.");

            // OpeningDays doğrulaması: Boş olamaz
            RuleFor(x => x.OpeningDays)
                .NotEmpty().WithMessage("Açılış günleri boş olamaz.");

            // OpeningHours doğrulaması: Boş olamaz
            RuleFor(x => x.OpeningHours)
                .NotEmpty().WithMessage("Açılış saatleri boş olamaz.");
        }
    }
}
