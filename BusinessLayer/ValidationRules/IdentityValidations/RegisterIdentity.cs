using DTOLayer.IdentityDto;
using FluentValidation;

namespace BusinessLayer.ValidationRules.IdentityValidations
{
    public class RegisterIdentity : AbstractValidator<RegisterDto>
    {
        public RegisterIdentity()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ad alanı gereklidir.")
                .Length(1, 50).WithMessage("Ad en fazla 50 karakter olabilir.");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Soyad alanı gereklidir.")
                .Length(1, 50).WithMessage("Soyad en fazla 50 karakter olabilir.");

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Kullanıcı adı gereklidir.")
                .Length(5, 20).WithMessage("Kullanıcı adı en az 5, en fazla 20 karakter olmalıdır.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta adresi gereklidir.")
                .EmailAddress().WithMessage("Geçersiz e-posta adresi.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre gereklidir.")
                .MinimumLength(6).WithMessage("Şifre en az 6 karakter uzunluğunda olmalıdır.")
                .Matches(@"[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir.")
                .Matches(@"[a-z]").WithMessage("Şifre en az bir küçük harf içermelidir.")
                .Matches(@"[0-9]").WithMessage("Şifre en az bir rakam içermelidir.")
                .Matches(@"[\W_]").WithMessage("Şifre en az bir özel karakter içermelidir.");
        }
    }
}
