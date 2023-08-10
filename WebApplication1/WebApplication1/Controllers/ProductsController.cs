using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositores;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepo repo;
        public ProductsController(IProductRepo repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            return View(await repo.GetAllAsync());
        }
        public async  Task<IActionResult> Create()
        {
            ViewBag.Customers = await repo.GetCustomers();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            await repo.InsertAsync(product);
            ViewBag.Customers = await repo.GetCustomers();
            await repo.CompleteAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Customers = await repo.GetCustomers();
            return View(await repo.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            await repo.UpdateAsync(product);
            ViewBag.Customers = await repo.GetCustomers();
            await repo.CompleteAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.Customers = await  repo.GetCustomers();
            return View(await repo.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Product product)
        {
            await repo.DeleteAsync(product);
            ViewBag.Customers = await repo.GetCustomers();
            await repo.CompleteAsync();
            return RedirectToAction("Index");
        }
    }
}
