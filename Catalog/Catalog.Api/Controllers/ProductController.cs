using Catalog.Application.DTOs.Products;
using Catalog.Application.Features.Products.Requests.Queries;
using Catalog.Domain.Entities;
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
        public async Task<ActionResult<ProductListDto>> Get( int id = 0, string name = null, string categoryName = null, decimal minPrice = 0, decimal maxPrice = 0)
        {
            // TODO: Product by attribute search operation will be written in Get action

            var products = await _mediator.Send(new GetProductListRequest
            {
                Id = id,
                Name = name,
                CategoryName = categoryName,
                MinPrice = minPrice,
                MaxPrice = maxPrice
            });

            return Ok(products);
        }

        [HttpPost]
        public void Post([FromBody] ProductCreateDto product)
        {
            // TODO: Product create operation will to be written
        }

        [HttpPut]
        public void Put([FromBody] ProductUpdateDto product)
        {
            // TODO: Product update operation will to be written
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // TODO: Product delete operation will to be written
        }
    }
}
