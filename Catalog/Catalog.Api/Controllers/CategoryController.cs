using Catalog.Application.DTOs.Categories;
using Catalog.Application.DTOs.Test;
using Catalog.Application.Features.Categories.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<CategoryListDto>> Get(string name, [FromQuery] int[] attributes)
        {
            // TODO: Category by attribute search operation will be written in Get action

            var categories = await _mediator.Send(new GetCategoryListRequest
            {
                Name = name,
                Attributes = attributes
            });

            return Ok(categories);
        }

        [HttpPost]
        public void Post([FromBody] CategoryCreateDto category)
        {
            // TODO: Category create operation will to be written
        }

        [HttpPut]
        public void Put(int id, [FromBody] CategoryUpdateDto category)
        {
            // TODO: Category update operation will to be written
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // TODO: Category delete operation will to be written
        }
    }
}
