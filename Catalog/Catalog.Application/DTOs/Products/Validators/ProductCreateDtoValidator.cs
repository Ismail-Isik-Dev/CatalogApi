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

            Include(new IProductDtoValidator(_categoryRepository));
        }
    }
}
