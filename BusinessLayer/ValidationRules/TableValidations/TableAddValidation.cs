using DTOLayer.TableDto;
using FluentValidation;

namespace BusinessLayer.ValidationRules.TableValidations
{
    public class TableAddValidation : AbstractValidator<InsertTableDto>
    {
        public TableAddValidation()
        {
            // Name doğrulaması: Boş olamaz
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Masa adı boş olamaz.");
        }
    }
}
