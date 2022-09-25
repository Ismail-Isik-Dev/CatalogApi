using Catalog.Application.DTOs.Categories;
using Catalog.Application.Features.Categories.Requests.Commands;
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
        public async Task<ActionResult<CategoryListDto>> Get(int id = 0, string name = null, [FromQuery] string[] attributes = null)
        {
            var categories = await _mediator.Send(new GetCategoryListRequest
            {
                Name = name,
                Attributes = attributes,
                Id = id
            });

            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryCreateDto category)
        {
            var createdCategoryId = await _mediator.Send(new CreateCategoryCommand
            {
                Category = category
            });

            return RedirectToAction("Get", new { id = createdCategoryId });
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] CategoryUpdateDto category)
        {
            await _mediator.Send(new UpdateCategoryCommand
            {
                Category = category
            });

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteCategoryCommand
            {
                Id = id
            });

            return Ok();
        }
    }
}
