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
            // TODO: Product create operation will be refactored

            var validator = new CategoryCreateDtoValidator(_categoryRepository);

            var validationResult = await validator.ValidateAsync(request.Category);

            if (!validationResult.IsValid)
            {
                throw new Exception("Validation Error!");
            }

            var categoryToCreate = _mapper.Map<Category>(request.Category);

            var createdCategory = await _categoryRepository.CreateAsync(categoryToCreate);

            return createdCategory.Id;
        }
    }
}
