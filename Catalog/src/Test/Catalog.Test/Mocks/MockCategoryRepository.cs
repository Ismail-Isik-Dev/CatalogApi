using Catalog.Application.Persistence.Contracts;
using Catalog.Domain.Common;
using Catalog.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;

namespace Catalog.Test.Mocks
{
    public static class MockCategoryRepository
    {
        public static Mock<ICategoryRepository> GetCategoryRepository() 
        {
            var categories = new List<Category>()
            {
               new Category
                {
                    Id = 1,
                    Name = "Smart Phone",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Status = Status.Active
                },
                new Category
                {
                    Id = 2,
                    Name = "Computer",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Status = Status.Active
                },
            };

            var mockRepository = new Mock<ICategoryRepository>();

            mockRepository.Setup(x => x.GetAllAsync(null)).ReturnsAsync(categories);

            mockRepository.Setup(x => x.CreateAsync(It.IsAny<Category>())).ReturnsAsync((Category category) =>
            {
                categories.Add(category);

                return category;
            });

            return mockRepository;
        }
    }
}
