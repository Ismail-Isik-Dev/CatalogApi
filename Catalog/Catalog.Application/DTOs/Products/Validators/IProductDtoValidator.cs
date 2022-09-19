using Catalog.Application.Persistence.Contracts;
using FluentValidation;

namespace Catalog.Application.DTOs.Products.Validators
{
    public class IProductDtoValidator : AbstractValidator<IProductDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        public IProductDtoValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(300).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}.");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var categoryIsExist = await _categoryRepository.AnyAsync(x => x.Id == id);

                    return !categoryIsExist;
                }).WithMessage("{PropertyName} does not exist.");

        }
    }
}
