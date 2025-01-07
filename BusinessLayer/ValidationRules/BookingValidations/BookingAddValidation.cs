using DTOLayer.BookingDto;
using FluentValidation;

namespace BusinessLayer.ValidationRules.BookingValidations
{
    public class BookingAddValidation : AbstractValidator<InsertBookingDto>
    {
        public BookingAddValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Alanı Boş Geçilemez");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("İsim Alanı En Az 3 Karakter Olmalıdır");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("İsim Alanı En Fazla 50 Karakter Olmalıdır");

            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon Alanı Boş Geçilemez");
            RuleFor(x => x.Phone).MinimumLength(10).WithMessage("Telefon Alanı En Az 10 Karakter Olmalıdır");
            RuleFor(x => x.Phone).MaximumLength(20).WithMessage("Telefon Alanı En Fazla 20 Karakter Olmalıdır");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email Alanı Boş Geçilemez");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli Bir Email Adresi Giriniz");
            RuleFor(x => x.Email).MaximumLength(100).WithMessage("Email Alanı En Fazla 100 Karakter Olmalıdır");

            RuleFor(x => x.PersonCount).NotEmpty().WithMessage("Kişi Sayısı Alanı Boş Geçilemez");
            RuleFor(x => x.PersonCount).InclusiveBetween(1, 10).WithMessage("Kişi Sayısı Alanı 1 ile 10 Arasında Olmalıdır");

            RuleFor(x => x.Description).MaximumLength(250).WithMessage("Açıklama Alanı En Fazla 250 Karakter Olmalıdır");

            RuleFor(x => x.Date).NotEmpty().WithMessage("Tarih Alanı Boş Geçilemez");
            RuleFor(x => x.Date).Must(x => x.Date > System.DateTime.Now).WithMessage("Tarih Alanı Bugünden Küçük Olamaz");

        }
    }
}
