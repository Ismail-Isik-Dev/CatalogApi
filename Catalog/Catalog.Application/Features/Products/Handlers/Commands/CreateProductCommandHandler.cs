using AutoMapper;
using Catalog.Application.DTOs.Products.Validators;
using Catalog.Application.Features.Products.Requests.Commands;
using Catalog.Application.Persistence.Contracts;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.Features.Products.Handlers.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // TODO: Product create operation will be refactored

            var validator = new ProductCreateDtoValidator(_categoryRepository);

            var validationResult = await validator.ValidateAsync(request.Product);

            if (!validationResult.IsValid)
            {
                throw new Exception("Validation Exception!");
            }

            var productToCreate = _mapper.Map<Product>(request.Product);

            var createdProduct = await _productRepository.CreateAsync(productToCreate);

            return createdProduct.Id;
        }
    }
}
