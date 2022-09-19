using AutoMapper;
using Catalog.Application.DTOs.Categories;
using Catalog.Application.Features.Categories.Requests.Queries;
using Catalog.Application.Persistence.Contracts;
using Catalog.Application.Utilities;
using Catalog.Domain.Entities;
using MediatR;
using System;

namespace Catalog.Application.Features.Categories.Handlers.Queries
{
    public class GetCategoryListRequestHandler : IRequestHandler<GetCategoryListRequest, CategoryListDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryListRequestHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryListDto> Handle(GetCategoryListRequest request, CancellationToken cancellationToken)
        {
            var predicate = SearchPredicateBuilder.True<Category>();

            if (request.Name != null)
            {
                predicate = predicate.And(x => x.Name == request.Name);
            }

            //if (request.Attributes.Any())
            //{
            //    foreach (var attribute in request.Attributes)
            //    {
            //        predicate = predicate.And(x => x.Attributes.Any(x => x.AttributeId == attribute.Id));
            //    }
            //}
            if (request.Attributes != null)
            {
                foreach (var attribute in request.Attributes)
                {
                    predicate = predicate.And(x => x.CategoryAttributes.Any(x => x.AttributeId == attribute));
                }   
            }

            var categoryList = await _categoryRepository.GetAllAsync(predicate, x => x.CategoryAttributes);

            // var categoryListDto = _mapper.Map<List<CategoryDto>>(categoryList);   

            return new CategoryListDto() { Categories = categoryList };
        }
    }
}
