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
- `DELETE /api/Users` – Delete user ✅
- `PUT /api/Users` – Update user data ✅
- `PATCH /api/Users/Password` – Update User Password ✅
- `PATCH /api/Users` – Update user as VIP ✅
- `GET /api/Users` – Get all logged user data ✅

### Movies
- `GET(ALL Movies) /api/Movies` ✅
- `GET /api/Movies/{id}` ✅
- `POST /api/Movies` ✅
- `PUT /api/Movies/{id}` ✅
- `DELETE /api/Movies/{id}` ✅

### Reports (VIP only)
- `GET /api/Reports/movies-pdf` ✅
   - With query params: `GET /api/Reports/movies-pdf?stars=3`

- `GET /api/Reports/movies-excel` ✅
   - With query params: `GET /api/Reports/movies-excel?stars=5`

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
<img width="1472" height="1127" alt="image" src="https://github.com/user-attachments/assets/2a21e6f3-71aa-4522-a4f6-2a1402a24296" />

### 📃 Excel Preview
<img width="970" height="501" alt="image" src="https://github.com/user-attachments/assets/afdb2b13-4686-4aae-a78c-ec5842f572c8" />

### 📃 PDF Preview
<img width="785" height="991" alt="image" src="https://github.com/user-attachments/assets/53c13c97-3e2a-4774-bf16-baa9a3acd32b" />
<img width="571" height="878" alt="image" src="https://github.com/user-attachments/assets/64092b8b-f4b4-4ceb-ba1e-f84a7352555f" />




## 🛠️ Tech Stack
- **ASP.NET Core** – API development.
- **MySQL** – Database for persistence.
- **Entity Framework Core** – Modern ORM for .NET, used for database access, migrations, and data management.
- **MySql** - DB
- **xUnit** – Unit and integration testing.
- **Shoudly** - Tests assertion.
- **MOQ** - Tests assertion.
- **EF Core SQLite In-Memory.** - In Memory DB for integration testing
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

Testing improvements include:
- Unit tests using in-memory providers
- Integration tests with in-memory sqlite database
- Coverage for:
  - Application services
  - Authentication and authorization flows
  - API controllers
  
## ✅ Implemented Unit Tests
Login:
- **Login Use Case** - User Login. ✅

Users:
- **Add User Use Case** – Creates a new user. ✅
- **Delete User Use Case** – Delete user ✅
- **Get All User Data Use Case** – Returns all logged user data ✅
- **Patch Vip User Use Case** – Updates user role to VIP ✅
- **Update User Use Case** – Updates user data ✅
- **Update User Password Use Case** – Update user Password ✅
- **Add User Validator** – Validates user request body params. ✅
- **Password Validator** – Validates user password body params. ✅

Movies:
- **Add Movie Use Case** – Create a new movie. ✅
- **Delete Movie Use Case** - Delete a movie. ✅
- **MoviesValidator** - Validates movie request body params. ✅

## ✅ Implemented Integration Tests

Users:
- `POST /api/Users` – Creates a new user ✅

Login: 
- `POST /api/Login` – Authenticate and receive a JWT token ✅

Movies:
- `POST /api/Movies` – Create a movie with authenticated user ✅

## ❌ Pending Unit Tests

Movies:
 - Retrieve all movies ❌
 - Retrieve a movie by ID ❌
 - Update an existing movie ❌

Reports:
 - Generate movies report in PDF ❌
 - Generate movies report in Excel ❌

## ❌ Missing Integration Tests
Users:
- `DELETE /api/Users` – Delete user ❌
- `PUT /api/Users` – Update user info ❌
- `PUT /api/Users/Password` – Update User Password ❌
- `PATCH /api/Users` – Update user as VIP ❌
- `GET /api/Users` – Get All Logged User Data ❌

Movies:
- `GET /api/Movies` – Retrieve all movies ❌
- `GET /api/Movies/{id}` – Retrieve movie by ID ❌
- `PUT /api/Movies/{id}` – Update movie ❌  
- `DELETE /api/Movies/{id}` – Delete movie ❌

Reports (VIP Only):
- `GET /api/Reports/movies-pdf` - Generates a PDF with all user critics.❌
- `GET /api/Reports/movies-excel` - Generates an Excel with all user critics.❌


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


