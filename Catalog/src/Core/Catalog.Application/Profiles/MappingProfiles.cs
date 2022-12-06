using AutoMapper;
using Catalog.Application.DTOs.Categories;
using Catalog.Application.DTOs.Products;
using Catalog.Domain.Entities;

namespace Catalog.Application.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            #region Product
            CreateMap<Product, ProductCreateDto>().ReverseMap();
            CreateMap<Product, ProductUpdateDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductAttribute, ProductAttributesAddDto>().ReverseMap();
            #endregion Product

            #region Category
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateDto>().ReverseMap();
            CreateMap<Category, CategoryUpdateDto>().ReverseMap();
            CreateMap<CategoryAttribute, CategoryAttributesAddDto>().ReverseMap();
            #endregion Category
        }
    }
}
