using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Repositores
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly InfinityContext db;
        public CustomerRepo(InfinityContext db)
        {
            this.db = db;
        }
        public async Task CompleteAsync()
        {
             await db.SaveChangesAsync();  
        }

        public async Task DeleteAsync(Customer customer)
        {
            db.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await Task.CompletedTask;

        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await db.Customers.ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await db.Customers.FirstAsync(c => c.CustomerId == id);
        }

        public async Task InsertAsync(Customer customer)
        {
             await db.Customers.AddAsync(customer);
        }

        public async Task UpdateAsync(Customer customer)
        {
            db.Entry(customer).State = EntityState.Modified;
            await Task.CompletedTask;
        }
    }
}
