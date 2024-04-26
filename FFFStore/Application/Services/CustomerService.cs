using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services;

public class CustomerService(IBaseRepository<Customer> customerRepository) : IBaseService<Customer>
{   
    public async Task<Customer> CreateAsync(Customer building, CancellationToken token = default)
    {
        return await customerRepository.CreateAsync(building, token);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken token = default)
    {
        var building = await customerRepository.GetAsync(id, token);

        if (building == null)
            return false;

        return await customerRepository.DeleteAsync(building, token);
    }

    public async Task<IEnumerable<Customer>> GetAllAsync(CancellationToken token = default)
    {
        return await customerRepository.GetAllAsync(token);
    }

    public async Task<Customer> GetAsync(Guid id, CancellationToken token = default)
    {
        return await customerRepository.GetAsync(id, token);
    }

    public async Task<bool> UpdateAsync(Customer building, CancellationToken token = default)
    {
        var buildingExist = await customerRepository.GetAsync(building.Id, token);

        if (buildingExist == null)
        {
            return false;
        }

        return await customerRepository.UpdateAsync(building, token);
    }
}