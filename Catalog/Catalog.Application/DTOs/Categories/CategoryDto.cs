﻿using Catalog.Application.DTOs.Common;

namespace Catalog.Application.DTOs.Categories
{
    public class CategoryDto : BaseDto, ICategoryDto
    {
        public string Name { get; set; }
    }
}
