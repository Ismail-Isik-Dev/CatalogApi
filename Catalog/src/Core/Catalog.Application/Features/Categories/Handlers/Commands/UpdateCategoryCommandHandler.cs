using AutoMapper;
using Catalog.Application.DTOs.Categories.Validators;
using Catalog.Application.Exceptions;
using Catalog.Application.Features.Categories.Requests.Commands;
using Catalog.Application.Persistence.Contracts;
using Catalog.Application.Utilities.Result.Contract;
using Catalog.Domain.Entities;
using Catalog.Persistance.Utilities.Result;
using MediatR;

namespace Catalog.Application.Features.Categories.Handlers.Commands
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, IResult>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var isCategoryExist = await _categoryRepository.AnyAsync(x => x.Id == request.Category.Id);

            if (!isCategoryExist)
            {
                throw new NotFoundException(nameof(Category), request.Category.Id);
            }

            var validator = new CategoryUpdateDtoValidator(_categoryRepository);

            var validationResult = await validator.ValidateAsync(request.Category);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var category = await _categoryRepository.GetAsync(x => x.Id == request.Category.Id);

            _mapper.Map(request.Category, category);

            await _categoryRepository.UpdateAsync(category);

            return new SuccessResult($"Category with Id: {request.Category.Id} is updated.");
        }
    }
}
