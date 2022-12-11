using AutoMapper;
using Catalog.Application.Exceptions;
using Catalog.Application.Features.Categories.Requests.Commands;
using Catalog.Application.Persistence.Contracts;
using Catalog.Application.Utilities.Result.Contract;
using Catalog.Domain.Common;
using Catalog.Domain.Entities;
using Catalog.Persistance.Utilities.Result;
using MediatR;

namespace Catalog.Application.Features.Categories.Handlers.Commands
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, IResult>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var deleteToCategory = await _categoryRepository.GetAsync(x => x.Id == request.Id);

            if (deleteToCategory == null)
            {
                throw new NotFoundException(nameof(Category), request.Id);
            }

            deleteToCategory.Status = Status.Deleted;

            await _categoryRepository.UpdateAsync(deleteToCategory);

            return new SuccessResult($"Category with Id: {request.Id} is deleted.");
        }
    }
}
