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

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<ProductListDto>> Get( int Id = 0, string Name = null, string CategoryName = null, decimal MinPrice = 0, decimal MaxPrice = 0)
        {
            var products = await _mediator.Send(new GetProductListRequest
            {
                Id = Id,
                Name = Name,
                CategoryName = CategoryName,
                MinPrice = MinPrice,
                MaxPrice = MaxPrice
            });

            return Ok(products);
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
