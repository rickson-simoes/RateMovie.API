# 🎬 Movie.API  

An application built with **ASP.NET Core** following **DDD (Domain-Driven Design)** architecture for managing movies.  
The system allows adding, listing movies and editing. 

## 🚀 Features

### ✅ Implemented
- **GET /movies** → Returns all registered movies.  
- **POST /movies** → Adds a new movie.
- **PUT /movies/{id}** → Edit an existing movie. 

### 🔜 Coming soon
- **DELETE /movies/{id}** → Delete a movie.  
- **Reports**  
  - Generate **PDF** report of inserted movies.  
  - Generate **Excel** report of inserted movies.  

## 🛠️ Tech Stack
- **ASP.NET Core** – API development.  
- **MySQL** – Database for persistence.  
- **xUnit** – Unit and integration testing.  
- **Bogus** – Fake data generation for testing scenarios.

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

---