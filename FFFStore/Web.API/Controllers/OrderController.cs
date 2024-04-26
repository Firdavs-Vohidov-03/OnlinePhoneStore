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
    public class OrderController(IBaseService<Order> OrderService, IMapper mapper) : ControllerBase
    {
        [HttpPost(ApiEndpoints.Order.Create)]
        public async Task<IActionResult> Create([FromBody] CreateOrderRequest request, CancellationToken token)
        {
            var order = mapper.Map<Order>(request);

            var response = await OrderService.CreateAsync(order, token);
            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }

        [HttpGet(ApiEndpoints.Order.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken token)
        {
            var departmentExist = await OrderService.GetAsync(id, token);

            var response = mapper.Map<SingleOrderResponse>(departmentExist);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpGet(ApiEndpoints.Order.GetAll)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var departments = await OrderService.GetAllAsync(token);

            var response = mapper.Map<IEnumerable<SingleOrderResponse>>(departments);

            return Ok(response);
        }

        [HttpPut(ApiEndpoints.Order.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateOrderRequest? request,
            CancellationToken token)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

            Order order = await OrderService.GetAsync(id, token);

            order.OrderDate = request.OrderDate;
           

            await OrderService.UpdateAsync(order, token);

            var response = mapper.Map<SingleOrderResponse>(order);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpDelete(ApiEndpoints.Order.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            var response = await OrderService.DeleteAsync(id, token);

            return response ? Ok() : NotFound($"Order with ID {id} not found.");
        }
    }
}