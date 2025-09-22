# 🎬 Movie.API  
An ASP.NET Core application designed with Domain-Driven Design (DDD) principles to manage movie critics.
It supports adding, listing, editing, and deleting movies, as well as generating PDF and Excel reports.

## 🚀 Features

### ✅ Implemented
- **GET /movies** → Returns all registered movies.
- **GET By Id /movies/{id}** → Returns all registered movies. 
- **POST /movies** → Adds a new movie.
- **PUT /movies/{id}** → Edit an existing movie.
- **DELETE /movies/{id}** → Delete a movie.  
- **Reports** If the stars query parameter is provided (1–5), the report will only include movies with that rating; otherwise, it will include all rated movies.:
  - **GET /api/Reports/movies-excel?stars={1-5}** → Generates an **Excel** report of movies.  
  - **GET /api/Reports/movies-pdf?stars={1-5}** → Generates a **PDF** report of movies.



### 📃 Swagger Preview
<img width="1290" height="1051" alt="image" src="https://github.com/user-attachments/assets/54d7a207-a954-4b1f-8c53-ca714fefbb10" />

**Response types at each request**:
<img width="906" height="938" alt="image" src="https://github.com/user-attachments/assets/73996564-fb0f-4396-b986-ac0c557462e6" />

### 📃 Excel Preview
<img width="970" height="501" alt="image" src="https://github.com/user-attachments/assets/afdb2b13-4686-4aae-a78c-ec5842f572c8" />

### 📃 PDF Preview
<img width="808" height="1138" alt="image" src="https://github.com/user-attachments/assets/64b8ce87-1745-4ae7-87bf-b6c5fa45acf1" />
<img width="571" height="873" alt="image" src="https://github.com/user-attachments/assets/9732cf68-5285-4dc4-8055-6aa38e303f9a" />



## 🛠️ Tech Stack
- **ASP.NET Core** – API development.
- **MySQL** – Database for persistence.
- **Entity Framework Core** – Modern ORM for .NET, used for database access, migrations, and data management.
- **Pomelo.EF Core. MySql**
- **xUnit** – Unit and integration testing.
- **Bogus** – Fake data generation for testing scenarios.
- **ClosedXML** - Generates a custom Excel.
- **QuestPDF** - Generates a custom PDF.

## 📂 Architecture
- **Domain** → Entities, aggregates, and business rules.  
- **Application** → Use cases and application services.  
- **Infrastructure** → Concrete implementations (repositories, persistence, MySQL integration).  
- **Presentation (API)** → Controllers, middlewares, and endpoints.
- **Communication** → Defines **DTOs (Data Transfer Objects)** for handling input (requests) and output (responses), ensuring separation between API contracts and domain models.  
- **Exception Handling** → Centralized management of errors, including exception filters, standardized error messages, and resource files for multi-language support.  

### 🎭 Exception Filters
- Centralized error handling with standardized responses.  
- Improves API consumer experience by avoiding inconsistent error messages.  

### 🌍 Resource Files Languages
- Error and validation messages in **multiple languages**.  
- Based on the `Accept-Language` header, allowing support for different cultures.  

## 🧪 Testing
- **Unit Tests**: validated with **xUnit**, ensuring business rules work in isolation.
- **Bogus**: generates fake data to simulate real-world scenarios.  

## 🖥️ Running Locally 

Follow these steps to **run the API locally** with migrations and seed data:  

1. **Install prerequisites:**  
   - **.NET 8.0 SDK**
   - **MySQL 8.0.42** (or compatible)  
   - **Entity Framework Core CLI tool**:  
     ```bash
     dotnet tool install --global dotnet-ef
     ```  
     > Note: This tool is required to run migrations and update the database. 

2. **Run this command in the project root to seed the database, as the migrations are already included:**  
   ```bash
   dotnet ef database update --project src/RateMovie.Infraestructure --startup-project src/RateMovie.Api
   ```

