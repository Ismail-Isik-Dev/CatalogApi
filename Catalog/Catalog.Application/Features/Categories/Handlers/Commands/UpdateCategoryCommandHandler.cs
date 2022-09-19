using AutoMapper;
using Catalog.Application.DTOs.Categories.Validators;
using Catalog.Application.Features.Categories.Requests.Commands;
using Catalog.Application.Persistence.Contracts;
using MediatR;

namespace Catalog.Application.Features.Categories.Handlers.Commands
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            // TODO: Product update operation will be refactored

            var validator = new CategoryUpdateDtoValidator(_categoryRepository);

            var validationResult = await validator.ValidateAsync(request.Category);

            if (!validationResult.IsValid)
            {
                throw new Exception("Validation Error!");
            }

            var category = await _categoryRepository.GetAsync(x => x.Id == request.Category.Id);

            _mapper.Map(request.Category, category);

            await _categoryRepository.UpdateAsync(category);

            return Unit.Value;
        }
    }
}
