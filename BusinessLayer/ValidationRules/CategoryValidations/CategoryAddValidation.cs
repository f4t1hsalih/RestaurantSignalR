using DTOLayer.CategoryDto;
using FluentValidation;

namespace BusinessLayer.ValidationRules.CategoryValidations
{
    public class CategoryAddValidation : AbstractValidator<InsertCategoryDto>
    {
        public CategoryAddValidation()
        {
            // Name doğrulaması: Boş olamaz ve en az 3 karakter uzunluğunda olmalı
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Kategori adı boş olamaz.")
                .MinimumLength(3).WithMessage("Kategori adı en az 3 karakter uzunluğunda olmalıdır.");

        }
    }
}
