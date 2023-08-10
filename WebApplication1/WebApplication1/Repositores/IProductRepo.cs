using WebApplication1.Models;

namespace WebApplication1.Repositores
{
    public interface IProductRepo
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Product> GetByIdAsync(int id);
        Task InsertAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
        Task CompleteAsync();
    }
}
