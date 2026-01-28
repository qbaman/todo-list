# ✅ To-Do List — ASP.NET Core MVC

A clean and simple **ASP.NET Core MVC To-Do List application** built as a practice project to strengthen understanding of MVC architecture, HTTP request handling, and CSV file processing.

This project is intentionally small, readable, and easy to extend.

---

## ✨ Features

- View a list of tasks  
- Add new tasks  
- Mark tasks as **Done / Undo**  
- Set optional due dates  
- Delete tasks  
- Import tasks from a CSV file  
- Export tasks to a CSV file  
- Clean Bootstrap-based UI  
- Cross-platform (Windows & macOS)

---

## 🧱 Tech Stack

- **ASP.NET Core MVC**
- **C#**
- **Razor Views**
- **Bootstrap 5**
- **CsvHelper**
- **.NET 9**
- In-memory data storage (no database)

---

## 🗂️ Project Structure

### Models
- `TodoItem` — represents a task  
- `TodoCsvRow` — represents a CSV row for imports  

### Controllers
- `TodosController` — handles all task actions and CSV operations  

### Views
- Razor views for listing, creating, importing, and managing tasks  

### Services
- `CsvImportService` — handles CSV parsing and validation  

---

## 🌐 Routes

| Route | Description |
|------|------------|
| `/` | Main To-Do list |
| `/Todos/Create` | Add a new task |
| `/Todos/Import` | Import tasks from CSV |
| `/Todos/Export` | Export tasks to CSV |
| `POST /Todos/Toggle/{id}` | Mark task done / undo |
| `POST /Todos/Delete/{id}` | Delete task |
| `POST /Todos/SetDueDate/{id}` | Set task due date |

---

## 📄 CSV Import Format

```csv
Title,DueDate
Finish MVC practice,2026-02-01
Revise HTTP GET vs POST,
```
Title is required


Due Date is optional (yyyy-MM-dd)

---

## 🚀 Running the Project

### Prerequisites
- .NET 9 SDK

### Run locally
```
dotnet restore
dotnet run
```
Then open the URL shown in the terminal (e.g. http://localhost:5081).

---

### 🎯 Purpose
This project was built for practice and learning, focusing on:
Understanding the MVC pattern
Proper use of HTTP GET vs POST
Handling file uploads and downloads
Reading and writing CSV files
Writing clean, maintainable C# code

---

## ⚠️ Notes
Data is stored in memory and resets on restart
No authentication or database is used
