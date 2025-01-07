using DTOLayer.CategoryDto;
using FluentValidation;

namespace BusinessLayer.ValidationRules.CategoryValidations
{
    public class CategoryUpdateValidation : AbstractValidator<UpdateCategoryDto>
    {
        public CategoryUpdateValidation()
        {
            // Name doğrulaması: Boş olamaz ve en az 3 karakter uzunluğunda olmalı
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Kategori adı boş olamaz.")
                .MinimumLength(3).WithMessage("Kategori adı en az 3 karakter uzunluğunda olmalıdır.");

        }
    }
}
