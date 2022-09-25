using Catalog.Application.DTOs.Products;
using Catalog.Application.Features.Products.Requests.Commands;
using Catalog.Application.Features.Products.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<ProductListDto>> Get(int Id = 0, string Name = null, string CategoryName = null, decimal MinPrice = 0, decimal MaxPrice = 0,
            [FromQuery] string[] attributes = null)
        {
            var products = await _mediator.Send(new GetProductListRequest
            {
                Id = Id,
                Name = Name,
                CategoryName = CategoryName,
                MinPrice = MinPrice,
                MaxPrice = MaxPrice,
                Attributes = attributes
            });

            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductCreateDto product)
        {
            var createdProductId = await _mediator.Send(new CreateProductCommand
            {
                Product = product
            });

            return RedirectToAction("Get", new { id = createdProductId });
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ProductUpdateDto product)
        {
            await _mediator.Send(new UpdateProductCommand
            {
                Product = product
            });

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteProductCommand
            {
                Id = id
            });

            return Ok();
        }
    }
}
