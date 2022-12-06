using Catalog.Application.Persistence.Contracts;
using FluentValidation;

namespace Catalog.Application.DTOs.Categories.Validators
{
    public class ICategoryDtoValidator : AbstractValidator<ICategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;

        public ICategoryDtoValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
