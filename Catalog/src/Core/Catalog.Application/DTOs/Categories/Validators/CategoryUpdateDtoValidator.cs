using Catalog.Application.Persistence.Contracts;
using FluentValidation;

namespace Catalog.Application.DTOs.Categories.Validators
{
    public class CategoryUpdateDtoValidator : AbstractValidator<CategoryUpdateDto>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryUpdateDtoValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            Include(new ICategoryDtoValidator(_categoryRepository));
        }
    }
}
