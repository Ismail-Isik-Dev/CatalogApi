using Catalog.Application.Persistence.Contracts;
using FluentValidation;

namespace Catalog.Application.DTOs.Products.Validators
{
    public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
    {
        private readonly ICategoryRepository _categoryRepository;

        public ProductCreateDtoValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(x => x.CategoryId)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .GreaterThan(0)
               .MustAsync(async (id, token) =>
               {
                   var categoryIsExist = await _categoryRepository.AnyAsync(x => x.Id == id);

                   return categoryIsExist;
               }).WithMessage("{PropertyName} does not exist.");
        }
    }
}
