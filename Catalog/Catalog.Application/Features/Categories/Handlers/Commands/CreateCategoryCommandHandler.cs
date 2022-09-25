using AutoMapper;
using Catalog.Application.DTOs.Categories.Validators;
using Catalog.Application.Features.Categories.Requests.Commands;
using Catalog.Application.Persistence.Contracts;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.Features.Categories.Handlers.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryValidator = new CategoryCreateDtoValidator(_categoryRepository);
            var categoryAttributesValidator = new CategoryAttributesAddDtoValidator();

            var categoryValidationResult = await categoryValidator.ValidateAsync(request.Category);

            if (!categoryValidationResult.IsValid)
            {
                throw new Exception("Category Validation Error!");
            }

            var categoryToCreate = _mapper.Map<Category>(request.Category);

            var categoryAttributes = new List<CategoryAttribute>();

            foreach (var attribute in request.Category.CategoryAttributes)
            {
                var categoryAttributesValidationResult = await categoryAttributesValidator.ValidateAsync(attribute);

                if (!categoryAttributesValidationResult.IsValid)
                {
                    throw new Exception("Category Attributes Validation Error!");
                }

                categoryAttributes.Add(_mapper.Map<CategoryAttribute>(attribute));
            }

            var createdCategory = await _categoryRepository.CreateAsync(categoryToCreate);

            return createdCategory.Id;
        }
    }
}
