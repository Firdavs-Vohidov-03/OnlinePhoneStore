using Application.Services;
using AutoMapper;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController(IBaseService<Product> ProductService, IMapper mapper) : ControllerBase
    {
        [HttpPost(ApiEndpoints.Product.Create)]
        public async Task<IActionResult> Create([FromBody] CreateProductRequest request, CancellationToken token)
        {
            var product = mapper.Map<Product>(request);

            var response = await ProductService.CreateAsync(product, token);
            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }

        [HttpGet(ApiEndpoints.Product.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken token)
        {
            var departmentExist = await ProductService.GetAsync(id, token);

            var response = mapper.Map<SingleProductResponse>(departmentExist);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpGet(ApiEndpoints.Product.GetAll)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var departments = await ProductService.GetAllAsync(token);

            var response = mapper.Map<IEnumerable<SingleProductResponse>>(departments);

            return Ok(response);
        }

        [HttpPut(ApiEndpoints.Product.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateProductRequest? request,
            CancellationToken token)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

            Product  product= await ProductService.GetAsync(id, token);

            product.Name = request.Name;
           

            await ProductService.UpdateAsync(product, token);

            var response = mapper.Map<SingleProductResponse>(product);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpDelete(ApiEndpoints.Product.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            var response = await ProductService.DeleteAsync(id, token);

            return response ? Ok() : NotFound($"Product with ID {id} not found.");
        }
    }
}