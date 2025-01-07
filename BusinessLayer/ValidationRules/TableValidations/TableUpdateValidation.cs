using DTOLayer.TableDto;
using FluentValidation;

namespace BusinessLayer.ValidationRules.TableValidations
{
    public class TableUpdateValidation : AbstractValidator<UpdateTableDto>
    {
        public TableUpdateValidation()
        {
            // Name doğrulaması: Boş olamaz
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Masa adı boş olamaz.");
        }
    }
}
