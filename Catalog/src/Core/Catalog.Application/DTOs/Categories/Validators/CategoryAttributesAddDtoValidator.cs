using FluentValidation;

namespace Catalog.Application.DTOs.Categories.Validators
{
    public class CategoryAttributesAddDtoValidator : AbstractValidator<CategoryAttributesAddDto>
    {
        public CategoryAttributesAddDtoValidator()
        {
            RuleFor(x => x.AttributeId).NotEmpty().NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
