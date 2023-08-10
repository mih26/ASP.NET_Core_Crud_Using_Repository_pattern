using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Repositores
{
    public class ProductRepo : IProductRepo
    {
        private readonly InfinityContext db;
        public ProductRepo(InfinityContext db)
        {
            this.db = db;
        }

        public async Task CompleteAsync()
        {
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            db.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await db.Products.Include(c=> c.Customer).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await db.Products.Include(c => c.Customer).FirstAsync(x=> x.ProductId == id);
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await db.Customers.ToListAsync();
        }

        public async Task InsertAsync(Product product)
        {
            await db.Products.AddAsync(product);
        }

        public async Task UpdateAsync(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            await Task.CompletedTask;
        }
    }
}
