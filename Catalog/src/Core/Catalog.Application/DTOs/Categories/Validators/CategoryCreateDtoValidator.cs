using Catalog.Application.Persistence.Contracts;
using FluentValidation;

namespace Catalog.Application.DTOs.Categories.Validators
{
    public class CategoryCreateDtoValidator : AbstractValidator<CategoryCreateDto>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryCreateDtoValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.")
               .MustAsync(async (name, token) =>
                {
                    var categoryIsExist = await _categoryRepository.AnyAsync(x => x.Name == name);

                    return !categoryIsExist;
                }).WithMessage("{PropertyName} already exists.");

        }
    }
}
