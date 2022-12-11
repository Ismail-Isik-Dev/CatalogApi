using AutoMapper;
using Catalog.Application.DTOs.Products;
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
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, IDataResult<ProductDto>>
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

        public async Task<IDataResult<ProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validatorProduct = new ProductCreateDtoValidator(_categoryRepository);
            var validatorProductAttributes = new ProductAttributesAddValidator();

            var productValidationResult = await validatorProduct.ValidateAsync(request.Product);

            if (!productValidationResult.IsValid)
            {
                throw new ValidationException(productValidationResult);
            }

            var productToCreate = _mapper.Map<Product>(request.Product);

            var productAttributes = new List<ProductAttribute>();

            foreach (var attribute in request.Product.Attributes)
            {
                var ProductAttributesValidatorResult = validatorProductAttributes.Validate(attribute);

                if (!ProductAttributesValidatorResult.IsValid)
                {
                    throw new ValidationException(ProductAttributesValidatorResult);
                }

                productAttributes.Add(_mapper.Map<ProductAttribute>(attribute));
            }

            productToCreate.ProductAttributes = productAttributes;

            var createdProduct = await _productRepository.CreateAsync(productToCreate);

            return new SuccessDataResult<ProductDto>(_mapper.Map<ProductDto>(createdProduct));
        }
    }
}
