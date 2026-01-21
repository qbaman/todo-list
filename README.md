# ✅ To-Do List — ASP.NET Core MVC

A simple and clean **ASP.NET Core MVC To-Do List application** built to demonstrate the **Model–View–Controller (MVC)** pattern, HTTP GET/POST requests, and basic server-side rendering.

This project was created as part of learning **ASP.NET MVC** and is intentionally kept **simple, readable, and cross-platform**.

---

## ✨ Features

- View a list of tasks
- Add new tasks
- Mark tasks as **Done / Undo**
- Set an optional **due date** for each task
- Delete tasks
- Clean Bootstrap-based UI
- Runs on **Windows and macOS**

---

## 🧱 Tech Stack

- **ASP.NET Core MVC**
- **C#**
- **Razor Views**
- **Bootstrap 5**
- **.NET 9**
- In-memory data store (no database)

---

## 🧩 MVC Structure

- **Model**  
  `TodoItem` represents a task (title, completion state, due date).

- **View**  
  Razor views (`.cshtml`) render the UI for listing and creating tasks.

- **Controller**  
  `TodosController` handles HTTP requests (GET / POST) and controls application flow.

---

## 🌐 Routes

| Route | Description |
|------|------------|
| `/` | Main To-Do list |
| `/Todos` | View all tasks |
| `/Todos/Create` | Add a new task |
| POST `/Todos/Toggle/{id}` | Mark task done/undo |
| POST `/Todos/Delete/{id}` | Delete task |
| POST `/Todos/SetDueDate/{id}` | Set task due date |

---

## 🚀 Running the Project

### Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/download)

### Run locally
```bash
dotnet restore
dotnet run
