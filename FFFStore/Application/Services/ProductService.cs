using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services;

public class ProductService(IBaseRepository<Product> ProductRepository) : IBaseService<Product>
{   
    public async Task<Product> CreateAsync(Product building, CancellationToken token = default)
    {
        return await ProductRepository.CreateAsync(building, token);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken token = default)
    {
        var product = await ProductRepository.GetAsync(id, token);

        if (product == null)
            return false;

        return await ProductRepository.DeleteAsync(product, token);
    }

    public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken token = default)
    {
        return await ProductRepository.GetAllAsync(token);
    }

    public async Task<Product> GetAsync(Guid id, CancellationToken token = default)
    {
        return await ProductRepository.GetAsync(id, token);
    }

    public async Task<bool> UpdateAsync(Product building, CancellationToken token = default)
    {
        var buildingExist = await ProductRepository.GetAsync(building.Id, token);

        if (buildingExist == null)
        {
            return false;
        }

        return await ProductRepository.UpdateAsync(building, token);
    }
}