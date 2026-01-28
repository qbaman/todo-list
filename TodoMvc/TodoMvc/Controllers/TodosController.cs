using Microsoft.AspNetCore.Mvc;
using TodoMvc.Data;
using TodoMvc.Models;
using TodoMvc.Services;

namespace TodoMvc.Controllers
{
    public class TodosController : Controller
    {
        private readonly CsvImportService _csvImportService;

        public TodosController(CsvImportService csvImportService)
        {
            _csvImportService = csvImportService;
        }

        // GET: /Todos
        public IActionResult Index()
        {
            return View(TodoStore.GetAll());
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

        // POST: /Todos/Toggle/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Toggle(int id)
        {
            TodoStore.Toggle(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: /Todos/SetDueDate/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SetDueDate(int id, DateTime? dueDate)
        {
            TodoStore.SetDueDate(id, dueDate);
            return RedirectToAction(nameof(Index));
        }

        // POST: /Todos/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            TodoStore.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Todos/Import
        public IActionResult Import()
        {
            return View();
        }

        // POST: /Todos/Import
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Import(IFormFile csvFile)
        {
            if (csvFile == null || csvFile.Length == 0)
            {
                ModelState.AddModelError(string.Empty, "Please choose a CSV file to upload.");
                return View();
            }

            if (!csvFile.FileName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
            {
                ModelState.AddModelError(string.Empty, "File must be a .csv file.");
                return View();
            }

            using var stream = csvFile.OpenReadStream();
            var result = _csvImportService.ImportTodos(stream);

            if (result.HasErrors)
            {
                foreach (var err in result.Errors)
                    ModelState.AddModelError(string.Empty, err);

                return View();
            }

            // Add import items to store
            foreach (var item in result.Items)
                TodoStore.Add(item);

            TempData["Message"] = $"Imported {result.Items.Count} task(s) from CSV.";
            return RedirectToAction(nameof(Index));
        }
    }
}
