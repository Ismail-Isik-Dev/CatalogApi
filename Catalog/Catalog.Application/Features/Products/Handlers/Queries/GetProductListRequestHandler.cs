using Catalog.Application.DTOs.Products;
using Catalog.Application.Features.Products.Requests.Queries;
using Catalog.Application.Persistence.Contracts;
using Catalog.Application.Utilities;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.Features.Products.Handlers.Queries
{
    public class GetProductListRequestHandler : IRequestHandler<GetProductListRequest, ProductListDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public GetProductListRequestHandler(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<ProductListDto> Handle(GetProductListRequest request, CancellationToken cancellationToken)
        {
           var predicate = SearchPredicateBuilder.True<Product>();

            if (request.Id != 0)
            {
                predicate = predicate.And(x => x.Id == request.Id);
            }

            if (request.MaxPrice != 0 && request.MinPrice != 0)
            {
                predicate = predicate.And(x => x.Price >= request.MinPrice && x.Price <= request.MaxPrice);
            }

            if (request.Name != null)
            {
                predicate = predicate.And(x => x.Name == request.Name);
            }

            if (request.CategoryName != null)
            {
                var category = await _categoryRepository.CategoryByName(request.CategoryName);

                if (category != null)
                {
                    predicate = predicate.And(x => x.CategoryId == category.Id);
                }
            }

            //if (request.Attributes.Any())
            //{
            //    foreach(var attribute in request.Attributes)
            //    {
            //        predicate = predicate.And(x => x.Attributes.Any(x => x.AttributeId == attribute.Id && x.Value == attribute.Value));
            //    }
            //}

            var productList = await _productRepository.GetAllAsync(predicate , x => x.Attributes );

            return new ProductListDto() { Products = productList};
        }
    }
}
