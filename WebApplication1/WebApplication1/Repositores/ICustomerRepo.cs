using WebApplication1.Models;

namespace WebApplication1.Repositores
{
    public interface ICustomerRepo
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int id);
        Task InsertAsync (Customer customer);
        Task UpdateAsync (Customer customer);
        Task DeleteAsync (Customer customer);
        Task CompleteAsync();
    }
}
