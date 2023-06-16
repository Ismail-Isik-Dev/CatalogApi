using Catalog.Application.Persistence.Contracts;
using Catalog.Domain.Common;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Catalog.Test.Mocks
{
    public static class MockProductRepository
    {
        public static Mock<IProductRepository> GetProductRepository() 
        {
            var products = new List<Domain.Entities.Product> 
            {
                new Domain.Entities.Product
                {
                    Id = 1,
                    Name = "Test Product_1",
                    Price = 50,
                    CategoryId = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Status = Status.Active
                },
                 new Domain.Entities.Product
                 {
                     Id = 2,
                     Name = "Test Product_2",
                     Price = 100,
                     CategoryId = 2,
                     CreatedDate = DateTime.Now,
                     ModifiedDate = DateTime.Now,
                     Status = Status.Active
                 },
            };

            var mockRepository = new Mock<IProductRepository>();

            mockRepository.Setup(x => x.CreateAsync(It.IsAny<Domain.Entities.Product>())).ReturnsAsync((Domain.Entities.Product product) => 
            {
                products.Add(product);

                return product;
            });

            return mockRepository;
        }
    }
}
