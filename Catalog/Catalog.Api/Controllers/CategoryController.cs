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
        public async Task<ActionResult<CategoryListDto>> Get(string Name, [FromQuery] int[] Attributes)
        {
            var categories = await _mediator.Send(new GetCategoryListRequest
            {
                Name = Name,
                Attributes = Attributes
            });

            return Ok(categories);
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
