using Catalog.Application.Persistence.Contracts;
using Catalog.Domain.Entities;
using NSubstitute;
using System.Collections.Generic;
using Xunit;

namespace Catalog.Test
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            var CategoryRepoMoq = Substitute.For<ICategoryRepository>();
            CategoryRepoMoq.GetAllAsync(x => true).Returns(new List<Category>());

        }
    }
}