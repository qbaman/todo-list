using Microsoft.AspNetCore.Mvc;
using TodoMvc.Data;
using TodoMvc.Models;

namespace TodoMvc.Controllers
{
    public class TodosController : Controller
    {
        // GET: /Todos
        public IActionResult Index()
        {
            return View(TodoStore.Items);
        }

        // GET: /Todos/Create
        public IActionResult Create()
        {
            return View(new TodoItem());
        }

        // POST: /Todos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TodoItem item)
        {
            if (!ModelState.IsValid)
                return View(item);

            TodoStore.Add(item);
            return RedirectToAction(nameof(Index));
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            TodoStore.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SetDueDate(int id, DateTime? dueDate)
        {
            TodoStore.SetDueDate(id, dueDate);
            return RedirectToAction(nameof(Index));
        }
    }
}
