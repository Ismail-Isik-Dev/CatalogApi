using AutoMapper;
using Catalog.Application.DTOs.Categories;
using Catalog.Application.Features.Categories.Requests.Queries;
using Catalog.Application.Persistence.Contracts;
using Catalog.Application.Utilities;
using Catalog.Domain.Common;
using Catalog.Domain.Entities;
using MediatR;
using System;

namespace Catalog.Application.Features.Categories.Handlers.Queries
{
    public class GetCategoryListRequestHandler : IRequestHandler<GetCategoryListRequest, CategoryListDto>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryListRequestHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryListDto> Handle(GetCategoryListRequest request, CancellationToken cancellationToken)
        {
            var predicate = SearchPredicateBuilder.True<Category>();

            predicate = predicate.And(x => x.Status == Status.Active);

            if (request.Id != 0)
            {
                predicate = predicate.And(x => x.Id == request.Id);
            }

            if (request.Name != null)
            {
                predicate = predicate.And(x => x.Name == request.Name);
            }

            if (request.Attributes != null)
            {
                foreach (var attribute in request.Attributes)
                {
                    predicate = predicate.And(x => x.CategoryAttributes.Any(x => x.Attribute.Name == attribute));
                }
            }

            var categoryList = await _categoryRepository.GetCategoriesWithAttributes(predicate);

            return new CategoryListDto() { Categories = categoryList };
        }
    }
}
