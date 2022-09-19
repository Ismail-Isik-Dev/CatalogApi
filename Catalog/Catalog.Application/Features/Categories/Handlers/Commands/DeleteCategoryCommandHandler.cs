using AutoMapper;
using Catalog.Application.Features.Categories.Requests.Commands;
using Catalog.Application.Persistence.Contracts;
using Catalog.Domain.Common;
using MediatR;

namespace Catalog.Application.Features.Categories.Handlers.Commands
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var deleteToCategory = await _categoryRepository.GetAsync(x => x.Id == request.Id);

            if (deleteToCategory == null)
            {
                throw new Exception("Category not found!");
            }

            deleteToCategory.Status = Status.Active;

            await _categoryRepository.UpdateAsync(deleteToCategory);

            return Unit.Value;  
        }
    }
}
