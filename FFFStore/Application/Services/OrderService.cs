using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services;

public class OrderService(IBaseRepository<Order> orderRepository) : IBaseService<Order>
{   
    public async Task<Order> CreateAsync(Order building, CancellationToken token = default)
    {
        return await orderRepository.CreateAsync(building, token);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken token = default)
    {
        var building = await orderRepository.GetAsync(id, token);

        if (building == null)
            return false;

        return await orderRepository.DeleteAsync(building, token);
    }

    public async Task<IEnumerable<Order>> GetAllAsync(CancellationToken token = default)
    {
        return await orderRepository.GetAllAsync(token);
    }

    public async Task<Order> GetAsync(Guid id, CancellationToken token = default)
    {
        return await orderRepository.GetAsync(id, token);
    }

    public async Task<bool> UpdateAsync(Customer building, CancellationToken token = default)
    {
        var buildingExist = await orderRepository.GetAsync(building.Id, token);

        if (buildingExist == null)
        {
            return false;
        }

        return await orderRepository.UpdateAsync(building: building, token);
    }

    public Task<bool> UpdateAsync(Order entity, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}