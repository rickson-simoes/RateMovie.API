# 🎬 Movie.API

**Movie.API** is an ASP.NET Core Web API built using **Domain-Driven Design (DDD)** principles, focused on managing movie ratings and reviews with proper authentication, authorization, and reporting capabilities.
Users can create accounts, authenticate, and perform full CRUD operations on movies. Certain features, such as report generation, are restricted to privileged users via role-based authorization.

---

## 🚀 Features

- User registration and authentication
- JWT-based authentication with ASP.NET Core Identity
- Role-based authorization (e.g. **VIP** users)
- CRUD operations for movies
- PDF and Excel report generation (VIP only)
- Swagger UI configured with JWT Authorization
- Clean and layered architecture (DDD-oriented)

---

## 📦 Endpoints Overview

### Authentication
- `POST /api/Login` – Authenticate and receive a JWT token ✅

### Users
- `POST /api/Users` – Create a new user ✅

### Movies
- `GET /api/Movies` - 🔜 (Updates incomming - No auth yet)
- `GET /api/Movies/{id}` - 🔜 (Updates incomming - No auth yet)
- `POST /api/Movies` ✅
- `PUT /api/Movies/{id}` - 🔜 (Updates incomming - No auth yet)
- `DELETE /api/Movies/{id}` - 🔜 (Updates incomming - No auth yet)

### Reports (VIP only)
- `GET /api/Reports/movies-pdf` - 🔜 (Updates incomming - No auth yet) 
- `GET /api/Reports/movies-excel` - 🔜 (Updates incomming - No auth yet) 

---

## 🔐 Authentication & Authorization

This API uses **ASP.NET Core Identity** combined with **JWT Bearer Tokens** to provide a secure authentication.

### Authentication Flow
1. User logs in via `/api/Login`
2. A JWT token is generated and returned
3. The token must be sent in the `Authorization` header.

## 🧪 Swagger (OpenAPI)

Swagger (OpenAPI 3.0) is enabled and fully configured to support JWT authentication.

### Usage:
1. Create an user through `/api/users`
2. Call `/api/Login` to obtain a token
3. Click **Authorize** in Swagger UI
4. Paste the token using the `Bearer YoUrAw3s0m3T0k3nJWT` scheme
5. Access secured endpoints directly from Swagger.


### 📃 Swagger Preview
<img width="1307" height="886" alt="image" src="https://github.com/user-attachments/assets/81aef4ee-9fc3-4a5b-85d1-c1bbe1d11df0" />

### 📃 Excel Preview
<img width="970" height="501" alt="image" src="https://github.com/user-attachments/assets/afdb2b13-4686-4aae-a78c-ec5842f572c8" />

### 📃 PDF Preview
<img width="808" height="1138" alt="image" src="https://github.com/user-attachments/assets/64b8ce87-1745-4ae7-87bf-b6c5fa45acf1" />
<img width="571" height="873" alt="image" src="https://github.com/user-attachments/assets/9732cf68-5285-4dc4-8055-6aa38e303f9a" />



## 🛠️ Tech Stack
- **ASP.NET Core** – API development.
- **MySQL** – Database for persistence.
- **Entity Framework Core** – Modern ORM for .NET, used for database access, migrations, and data management.
- **MySql** - DB
- **xUnit** – Unit and integration testing.
- **Shoudly** - Tests assertion.
- **MOQ** - Tests assertion.
- (Soon) **EF Core In Memory** - In Memoby DB for integration testing
- **Bogus** – Fake data generation for testing scenarios.
- **ClosedXML** - Generates a custom Excel.
- **QuestPDF** - Generates a custom PDF.
- **JWT Bearer Authentication**
- **Swagger**

## 📂 Architecture
- **Domain** → Entities, aggregates, and business rules.  
- **Application** → Use cases and application services.  
- **Infrastructure** → Concrete implementations (repositories, persistence, MySQL integration).  
- **Presentation (API)** → Controllers, middlewares, and endpoints.
- **Communication** → Defines **DTOs (Data Transfer Objects)** for handling input (requests) and output (responses), ensuring separation between API contracts and domain models.  
- **Exception Handling** → Centralized management of errors, including exception filters, standardized error messages, and resource files for multi-language support.

### Authorization
- Claims and roles are embedded in the JWT
- Endpoints are protected using `[Authorize]`
- Role-based access is enforced using `[Authorize(Roles = "Vip")]`
No cookies or sessions are used.

### 🎭 Exception Filters
- Centralized error handling with standardized responses.  
- Improves API consumer experience by avoiding inconsistent error messages.  

### 🌍 Resource Files Languages
- Error and validation messages in **multiple languages**.  
- Based on the `Accept-Language` header, allowing support for different cultures.  

## 🧪 Testing
- **Unit Tests**: validated with **xUnit**, ensuring business rules work in isolation.
- **Bogus**: generates fake data to simulate real-world scenarios.

❗ Upcoming testing improvements include:
- Unit tests using in-memory providers
- Integration tests with in-memory databases
- Coverage for:
  - Domain logic
  - Application services
  - Authentication and authorization flows
  - API controllers

## 🖥️ Running Locally 
Follow these steps to **run the API locally** with automatic migrations/seed data:

1. **Install prerequisites:**  
   - **.NET 8.0 SDK**
   - **MySQL Server 8.0.42** (or compatible)
   - Docker (Optional)
  
2. _**Installing/Connecting to MySQL Server using Docker (OPTIONAL):**_
    - _Download the Oficial MYSQL Docker Image: **mysql**_

    [![image](https://github.com/user-attachments/assets/0b5f9cc4-326e-4479-8ec8-6168d2e7f74e)](https://hub.docker.com/_/mysql)

    - Create a Docker container for MySQL, use the following command to run the container with MySQL 8.0 (Debian) and map the default port:
   ```cmd   
   docker run --name mySqlApp -e MYSQL_ROOT_PASSWORD=YOURPASSWORD -p 3306:3306 -d mysql:8.0-debian
   ```    

3. **Update the **`appsettings.Development.json`** file (inside `src/RateMovie.Api/appsettings.Development.json`) with your local MySQL credentials.**
```json
{
  "ConnectionStrings": {
    "ConnectionMYSQL": "server=localhost;user=root;password=YOURPASSWORD;database=CashFlowDB"
  }
}
```

4. **Execute through the startup project RateMovie.Api**
<br/>
 <img width="205" height="45" alt="image" src="https://github.com/user-attachments/assets/d33a01cb-34f2-41af-9264-59095ce65fd2" />


