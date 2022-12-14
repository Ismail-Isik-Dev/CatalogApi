using AutoMapper;
using Catalog.Application.DTOs.Products;
using Catalog.Application.Features.Products.Handlers.Queries;
using Catalog.Application.Features.Products.Requests.Queries;
using Catalog.Application.Persistence.Contracts;
using Catalog.Application.Profiles;
using Catalog.Application.Utilities.Result.Contract;
using Catalog.Persistance.Utilities.Result;
using Catalog.Test.Mocks;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Catalog.Test.Product.Queries
{
    public class GetProductListRequestHandlerTests
    {
        private readonly Mock<IProductRepository> _mockProductRepository;
        private readonly Mock<ICategoryRepository> _mockCategoryRepository;

        public GetProductListRequestHandlerTests()
        {
            _mockProductRepository = MockProductRepository.GetProductRepository();
            _mockCategoryRepository = MockCategoryRepository.GetCategoryRepository();
        }

        [Fact]
        public async Task GetProductListTest()
        {
            var handler = new GetProductListRequestHandler(_mockProductRepository.Object, _mockCategoryRepository.Object);

            var result = await handler.Handle(new GetProductListRequest(), CancellationToken.None);

            result.ShouldBeOfType<SuccessDataResult<ProductListDto>>();
            result.Data.Products.Count.ShouldBe(2);
        }
    }
}
