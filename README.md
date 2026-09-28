# Employee Management API

A backend learning project built with **ASP.NET Core Web API (.NET 8)**, **Entity Framework Core**, and **SQL Server**.

The purpose of this project is to strengthen practical backend development skills by building an Employee Management REST API from the ground up and gradually applying professional backend development concepts.

## Technologies

* C#
* ASP.NET Core Web API (.NET 8)
* Entity Framework Core
* SQL Server
* Swagger / OpenAPI
* Dependency Injection
* Async/Await

## Project Architecture

The application currently follows a simple layered architecture that separates HTTP handling from application logic and database access.

```text
Client
   ↓
Controller
   ↓
Service Layer
   ↓
Entity Framework Core
   ↓
SQL Server
```

### Controllers

Controllers are responsible for:

* Receiving HTTP requests
* Calling the appropriate service
* Returning HTTP responses

### Service Layer

The service layer separates application logic from the controllers.

Interfaces are used to keep the controller dependent on abstractions rather than concrete service implementations.

Example:

```text
IEmployeeService
       ↓
EmployeeService
```

### Entity Framework Core

Entity Framework Core is used as the ORM to communicate with SQL Server and perform database operations.

### Dependency Injection

ASP.NET Core's built-in dependency injection container is used to register and inject the `IEmployeeService` implementation into the controller.

This keeps the application loosely coupled and makes the components easier to maintain and test.

## Features

The API currently supports complete CRUD operations for employees:

* Create an employee
* Get all employees
* Get an employee by ID
* Update an employee
* Delete an employee

The database operations have been implemented using asynchronous EF Core methods where appropriate.

The read-only employee listing also uses `AsNoTracking()` to avoid unnecessary entity tracking.

## API Endpoints

| HTTP Method | Endpoint              | Description                 |
| ----------- | --------------------- | --------------------------- |
| GET         | `/api/Employees`      | Get all employees           |
| GET         | `/api/Employees/{id}` | Get an employee by ID       |
| POST        | `/api/Employees`      | Create a new employee       |
| PUT         | `/api/Employees/{id}` | Update an existing employee |
| DELETE      | `/api/Employees/{id}` | Delete an employee          |

## Example Employee

The API currently works with employee information such as:

```json
{
  "name": "Ali Raza",
  "email": "ali.raza@example.com",
  "department": "Software Engineering",
  "salary": 150000
}
```

## Database

The project uses **SQL Server** as the database and **Entity Framework Core** for database communication.

The current database contains an `Employees` table with fields including:

* ID
* Name
* Email
* Department
* Salary

The database was created and verified using **SQL Server Management Studio (SSMS)**.

## Asynchronous Programming

The CRUD operations use asynchronous EF Core methods for database I/O where appropriate.

Examples include:

```csharp
ToListAsync()
FindAsync()
SaveChangesAsync()
```

The application follows the asynchronous flow through the different layers:

```text
Controller
    ↓ await
Service
    ↓ await
Entity Framework Core
    ↓
SQL Server
```

The goal of using asynchronous database operations is to avoid unnecessarily blocking server threads while waiting for I/O operations to complete.

## EF Core Query Optimization

The employee listing uses:

```csharp
AsNoTracking()
```

for read-only queries.

Since the retrieved employees are not being modified in the GET operation, EF Core does not need to maintain change-tracking information for those entities.

This reduces unnecessary tracking overhead for read-only operations.

## Project Structure

The current project is organized approximately as follows:

```text
EmployeeManagement/
│
├── Controllers/
│   └── EmployeesController.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── Models/
│   └── Employee.cs
│
├── Services/
│   ├── IEmployeeService.cs
│   └── EmployeeService.cs
│
├── Properties/
│
├── appsettings.json
├── appsettings.Development.json
├── Program.cs
└── EmployeeManagement.csproj
```

## How to Run

### Prerequisites

You need the following installed:

* .NET 8 SDK
* SQL Server
* SQL Server Management Studio (SSMS)
* Visual Studio

### Database Configuration

The application currently uses a local SQL Server database.

Example connection string:

```text
Server=localhost;Database=EmployeeManagementDb;Trusted_Connection=True;TrustServerCertificate=True;
```

Update the connection string according to your local SQL Server configuration if required.

### Run the Application

1. Clone or download the repository.
2. Open the `.csproj` file in Visual Studio.
3. Make sure SQL Server is running.
4. Verify the database connection string.
5. Build the solution.
6. Run the application.
7. Open Swagger to test the API endpoints.

## Testing

The API endpoints have been tested using **Swagger / OpenAPI**.

CRUD operations have been tested for:

* Creating employees
* Retrieving employees
* Retrieving employees by ID
* Updating employees
* Deleting employees

The database changes have also been verified through SQL Server Management Studio.

## What I Have Learned

This project is being developed incrementally to understand not only how to make an API work, but also how to structure and optimize a backend application.

Concepts currently covered include:

* ASP.NET Core Web API
* REST API fundamentals
* HTTP methods
* Attribute-based routing
* Controller actions
* `IActionResult`
* Dependency Injection
* Interfaces and loose coupling
* Service-layer architecture
* Entity Framework Core
* SQL Server integration
* CRUD operations
* Async/Await
* Asynchronous database operations
* `Task<T>`
* EF Core `AsNoTracking()`
* Basic backend performance considerations

## Planned Improvements

This project will continue to evolve as additional backend concepts are learned and implemented.

Planned improvements include:

* DTOs (`CreateEmployeeDto`, `UpdateEmployeeDto`, etc.)
* Projection using `Select()`
* Input validation
* Pagination
* Filtering and searching
* Global exception handling
* Logging
* Authentication and authorization
* Database and query optimization
* Proper HTTP status code handling
* Unit testing
* Integration testing
* Production-oriented architecture
* API documentation
* Improved error responses

## Purpose

This repository documents my practical journey of strengthening my backend development skills with .NET by building and continuously improving a working Web API.

The focus is not only on implementing features, but also on understanding **why** different architectural and performance decisions are made in real-world backend applications.

## Author

**Hammad Saif**

Software Engineer | .NET / Backend Development

This project is part of my ongoing effort to deepen my understanding of professional backend development with the .NET ecosystem.
