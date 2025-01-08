using DTOLayer.ProductDto;
using FluentValidation;

namespace BusinessLayer.ValidationRules.ProductValidations
{
    public class ProductAddValidation : AbstractValidator<InsertProductDto>
    {
        public ProductAddValidation()
        {
            // Name doğrulaması: Boş olamaz
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ürün adı boş olamaz.");

            // Price doğrulaması: Fiyat sıfırdan büyük olmalı
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Fiyat sıfırdan büyük olmalıdır.");

            // ImageUrl doğrulaması: Boş olamaz, geçerli bir URL formatında olmalı
            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Görsel URL'si boş olamaz.");

            // CategoryId doğrulaması: Geçerli bir kategori olmalı (pozitif bir tam sayı)
            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Geçerli bir kategori seçilmelidir.");

            // Description doğrulaması: En az 10, en fazla 500 karakter olmalı
            RuleFor(x => x.Description)
                .MinimumLength(10).WithMessage("Açıklama en az 10 karakter olmalıdır.")
                .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olmalıdır.");
        }
    }
}
