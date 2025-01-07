using DTOLayer.ProductDto;
using FluentValidation;

namespace BusinessLayer.ValidationRules.ProductValidations
{
    public class ProductUpdateValidation : AbstractValidator<UpdateProductDto>
    {
        public ProductUpdateValidation()
        {
            // Name doğrulaması: Boş olamaz
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ürün adı boş olamaz.");

            // Description doğrulaması: Boş olamaz
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama boş olamaz.");

            // Price doğrulaması: Fiyat sıfırdan büyük olmalı
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Fiyat sıfırdan büyük olmalıdır.");

            // ImageUrl doğrulaması: Boş olamaz, geçerli bir URL formatında olmalı
            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Görsel URL'si boş olamaz.");

            // CategoryId doğrulaması: Geçerli bir kategori olmalı (pozitif bir tam sayı)
            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Geçerli bir kategori seçilmelidir.");
        }
    }
}
