using AutoMapper;
using Catalog.Application.DTOs.Products.Validators;
using Catalog.Application.Features.Products.Requests.Commands;
using Catalog.Application.Persistence.Contracts;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.Features.Products.Handlers.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
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

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            // TODO: Product update operation will be refactored

            var validator = new ProductUpdateDtoValidator(_categoryRepository);

            var validatorResult = await validator.ValidateAsync(request.Product);

            if (!validatorResult.IsValid)
            {
                throw new Exception("Validation Exception!");
            }

            var productToUpdate = _mapper.Map<Product>(request.Product);

            await _productRepository.UpdateAsync(productToUpdate);

            return Unit.Value;
        }
    }
}
