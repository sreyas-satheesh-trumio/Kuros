# 🚀 Kuros — Modern Kanban Board with .NET 10 & Blazor WASM

Kuros is a **modern Kanban-style project and task management system** built with **.NET 10**, **ASP.NET Core Web API**, and **Blazor WebAssembly**.  
It showcases **real-world backend architecture**, **clean REST API design**, and a **modern SPA frontend**, following industry best practices.

> This project focuses on correctness, scalability, and clarity — not demo shortcuts.

---

## ✨ Features

### 🗂️ Project & Task Management
- Create, update, and delete **Projects**
- Create, update, move, and delete **TaskItems**
- Tasks belong to projects and follow a **Kanban workflow**

### 🔄 Kanban Workflow
- Task status transitions (e.g. Backlog → In Progress → Testing → Completed)
- Explicit API support for moving tasks between states
- Designed for drag-and-drop UI integration

### 🌐 RESTful API
- Clean, predictable REST endpoints
- Standard HTTP status codes
- **RFC 7807 ProblemDetails** error responses
- Global exception handling (no try/catch in controllers)

### 🧱 Architecture
- Clean separation of concerns:
  - **Core** → Domain, services, DTOs, EF Core
  - **API** → HTTP, DI, middleware, OpenAPI
  - **Web** → Blazor WebAssembly SPA
- Service-based business logic
- Thin controllers

### 🗄️ Data & Persistence
- Entity Framework Core
- SQL Server / SQL Express
- Code-first migrations
- Clean DbContext setup

### 🧪 Developer Experience
- Scalar API explorer (instead of Swagger)
- Clear error responses for frontend consumption
- Ready for extension (auth, SignalR, validation, etc.)

---

## 🏗️ Tech Stack

- **.NET 10**
- **ASP.NET Core Web API**
- **Blazor WebAssembly**
- **Entity Framework Core**
- **SQL Server / SQL Express**
- **Scalar (OpenAPI UI)**

---

## 📁 Solution Structure

```

Kuros.sln
├── Kuros.Core   # Domain, DTOs, services, DbContext
├── Kuros.Api    # REST API, middleware, OpenAPI
└── Kuros.Web    # Blazor WebAssembly frontend

````

---

## ▶️ How to Run the Application

### ✅ Prerequisites
- .NET SDK **10.0+**
- SQL Server / SQL Server Express / LocalDB

---

### 1️⃣ Clone the Repository

```bash
git clone https://github.com/your-username/kuros.git
cd kuros
````

---

### 2️⃣ Configure Database Connection

Update the connection string in:

```
Kuros.Api/appsettings.json
```

Example (SQL Server Express):

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_MACHINE\\SQLEXPRESS;Database=KurosDb;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

---

### 3️⃣ Restore & Build

```bash
dotnet restore
dotnet build
```

---

### 4️⃣ Apply Database Migrations

```bash
dotnet ef database update --project Kuros.Core --startup-project Kuros.Api
```

This creates the database and required tables.

---

### 5️⃣ Run the Backend API

```bash
dotnet run --project Kuros.Api
```

* API URL: `https://localhost:<port>`
* API Explorer (Scalar): `https://localhost:<port>/scalar`

---

### 6️⃣ Run the Frontend (Blazor WASM)

Open a new terminal:

```bash
dotnet run --project Kuros.Web
```

The application will open automatically in your browser.

---

## 🏁 Build for Production

```bash
dotnet build -c Release
```

---

## 📌 Notes

* The API uses **ProblemDetails** for all error responses
* All business logic lives outside controllers
* The architecture is ready for authentication, SignalR, and scaling

---

⭐ If you find this project useful, feel free to star the repository.


