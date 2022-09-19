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

            Include(new ICategoryDtoValidator(_categoryRepository));
        }
    }
}
