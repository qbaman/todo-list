using System.Collections.Generic;
using TodoMvc.Models;

namespace TodoMvc.Data
{
    public static class TodoStore
    {
        public static List<TodoItem> Items { get; } = new()
        {
            new TodoItem { Id = 1, Title = "Finish MVC To-Do demo", IsDone = false },
            new TodoItem { Id = 2, Title = "Push project to GitHub", IsDone = false }
        };

        private static int _nextId = 3;

        public static void Add(TodoItem item)
        {
            item.Id = _nextId++;
            Items.Add(item);
        }

        public static void Delete(int id)
        {
            var item = Items.Find(x => x.Id == id);
            if (item != null) Items.Remove(item);
        }

        public static void SetDueDate(int id, DateTime? dueDate)
        {
            var item = Items.Find(x => x.Id == id);
            if (item != null)
                item.DueDate = dueDate;
        }
    }
}
