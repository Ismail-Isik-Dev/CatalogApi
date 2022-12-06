using FluentValidation;

namespace Catalog.Application.DTOs.Products.Validators
{
    public class ProductAttributesAddValidator : AbstractValidator<ProductAttributesAddDto>
    {
        public ProductAttributesAddValidator()
        {
            RuleFor(x => x.AttributeId).NotNull().WithMessage("{PropertyName} must be present");
            RuleFor(x => x.Value).NotEmpty().NotNull().WithMessage("{PropertyName} is required.");
        }
    }
}
