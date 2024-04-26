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
    public class CustomerController(IBaseService<Customer> CustomerService, IMapper mapper) : ControllerBase
    {
        [HttpPost(ApiEndpoints.Customer.Create)]
        public async Task<IActionResult> Create([FromBody] CreateCustomerRequest request, CancellationToken token)
        {
            var customer = mapper.Map<Customer>(request);

            var response = await CustomerService.CreateAsync(customer, token);
            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }

        [HttpGet(ApiEndpoints.Customer.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken token)
        {
            var departmentExist = await CustomerService.GetAsync(id, token);

            var response = mapper.Map<SingleCustomerResponse>(departmentExist);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpGet(ApiEndpoints.Customer.GetAll)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var departments = await CustomerService.GetAllAsync(token);

            var response = mapper.Map<IEnumerable<SingleCustomerResponse>>(departments);

            return Ok(response);
        }

        [HttpPut(ApiEndpoints.Customer.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateCustomerRequest? request,
            CancellationToken token)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

            Customer  customer= await CustomerService.GetAsync(id, token);

            customer.Name = request.Name;
           

            await CustomerService.UpdateAsync(customer, token);

            var response = mapper.Map<SingleCustomerResponse>(customer);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpDelete(ApiEndpoints.Customer.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            var response = await CustomerService.DeleteAsync(id, token);

            return response ? Ok() : NotFound($"Customer with ID {id} not found.");
        }
    }
}