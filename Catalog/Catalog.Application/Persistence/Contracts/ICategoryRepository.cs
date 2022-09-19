using Catalog.Domain.Entities;

namespace Catalog.Application.Persistence.Contracts
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> CategoryByName(string name); 
    }
}
