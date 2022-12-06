using Catalog.Application.Persistence.Contracts;
using FluentValidation;

namespace Catalog.Application.DTOs.Products.Validators
{
    public class ProductUpdateDtoValidator : AbstractValidator<ProductUpdateDto>
    {
        private readonly ICategoryRepository _categoryRepository;

        public ProductUpdateDtoValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            Include(new IProductDtoValidator(_categoryRepository));

            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
