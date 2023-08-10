using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositores;

namespace WebApplication1.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerRepo repo;
        public CustomersController(ICustomerRepo repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            return View(await repo.GetAllAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            await repo.InsertAsync(customer);
            await repo.CompleteAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            return View(await repo.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Customer customer)
        {
            await repo.UpdateAsync(customer);
            await repo.CompleteAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            return View(await repo.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Customer customer)
        {
            await repo.DeleteAsync(customer);
            await repo.CompleteAsync();
            return RedirectToAction("Index");
        }
    }
}
