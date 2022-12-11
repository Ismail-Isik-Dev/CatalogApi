using AutoMapper;
using Catalog.Application.DTOs.Products.Validators;
using Catalog.Application.Exceptions;
using Catalog.Application.Features.Products.Requests.Commands;
using Catalog.Application.Persistence.Contracts;
using Catalog.Application.Utilities.Result.Contract;
using Catalog.Domain.Entities;
using Catalog.Persistance.Utilities.Result;
using MediatR;

namespace Catalog.Application.Features.Products.Handlers.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, IResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var isProductExist = await _productRepository.AnyAsync(x => x.Id == request.Product.Id);

            if (!isProductExist)
            {
                throw new NotFoundException(nameof(Product), request.Product.Id);
            }

            var validator = new ProductUpdateDtoValidator(_categoryRepository);

            var validatorResult = await validator.ValidateAsync(request.Product);

            if (!validatorResult.IsValid)
            {
                throw new ValidationException(validatorResult);
            }

            var productToUpdate = _mapper.Map<Product>(request.Product);

            await _productRepository.UpdateAsync(productToUpdate);

            return new SuccessResult($"Product with Id: {request.Product.Id} is updated.");
        }
    }
}
