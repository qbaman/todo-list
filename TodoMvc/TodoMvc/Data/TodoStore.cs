using System;
using System.Collections.Generic;
using System.Linq;
using TodoMvc.Models;

namespace TodoMvc.Data
{
    /// <summary>
    /// Simple in-memory storage for tasks (no database).
    /// Data resets when the app restarts.
    /// </summary>
    public static class TodoStore
    {
        private static readonly List<TodoItem> _items = new();
        private static int _nextId = 1;

        // Optional seed tasks (safe defaults)
        static TodoStore()
        {
            Add(new TodoItem { Title = "Finish ASP.NET MVC To-Do demo" });
            Add(new TodoItem { Title = "Push project to GitHub" });
            Add(new TodoItem { Title = "Submit work to Mohi" });
        }

        public static IReadOnlyList<TodoItem> GetAll()
        {
            return _items
                .OrderByDescending(t => t.CreatedAt)
                .ToList();
        }

        public static TodoItem? GetById(int id)
        {
            return _items.FirstOrDefault(t => t.Id == id);
        }

        public static void Add(TodoItem item)
        {
            item.Id = _nextId++;
            item.CreatedAt = DateTime.Now;
            _items.Add(item);
        }

        public static void Toggle(int id)
        {
            var item = GetById(id);
            if (item == null) return;

            item.IsDone = !item.IsDone;
        }

        public static void SetDueDate(int id, DateTime? dueDate)
        {
            var item = GetById(id);
            if (item == null) return;

            item.DueDate = dueDate;
        }

        public static void Delete(int id)
        {
            var item = GetById(id);
            if (item == null) return;

            _items.Remove(item);
        }
    }
}
