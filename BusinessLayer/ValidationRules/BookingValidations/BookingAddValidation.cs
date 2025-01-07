using DTOLayer.BookingDto;
using FluentValidation;

namespace BusinessLayer.ValidationRules.BookingValidations
{
    public class BookingAddValidation : AbstractValidator<InsertBookingDto>
    {
        public BookingAddValidation()
        {
            // İsim Validasyonu
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("İsim alanı boş geçilemez.")
                .MinimumLength(3).WithMessage("İsim alanı en az 3 karakter olmalıdır.")
                .MaximumLength(50).WithMessage("İsim alanı en fazla 50 karakter olmalıdır.");

            // Telefon Numarası Validasyonu
            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Telefon alanı boş geçilemez.")
                .Matches(@"^(\+90|0)?5[0-9]{9}$").WithMessage("Telefon numarası yalnızca sayılardan oluşmalı ve Türkiye formatına uygun olmalıdır (örneğin: +905XXXXXXXXX veya 05XXXXXXXXX).")
                .MaximumLength(13).WithMessage("Telefon alanı en fazla 13 karakter olmalıdır.");

            // Email Validasyonu
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email alanı boş geçilemez.")
                .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.")
                .MaximumLength(100).WithMessage("Email alanı en fazla 100 karakter olmalıdır.");

            // Kişi Sayısı Validasyonu
            RuleFor(x => x.PersonCount)
                .NotEmpty().WithMessage("Kişi sayısı alanı boş geçilemez.")
                .InclusiveBetween(1, 10).WithMessage("Kişi sayısı 1 ile 10 arasında olmalıdır.");

            // Açıklama Validasyonu
            RuleFor(x => x.Description)
                .MaximumLength(250).WithMessage("Açıklama alanı en fazla 250 karakter olmalıdır.");

            // Tarih Validasyonu
            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Tarih alanı boş geçilemez.")
                .Must(date => date.Date.Date >= System.DateTime.Now.Date).WithMessage("Tarih alanı bugünden küçük olamaz.");
        }
    }
}
