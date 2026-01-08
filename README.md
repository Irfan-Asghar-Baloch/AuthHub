# AuthHub – JWT Authentication & Role-Based Authorization

AuthHub is a Clean Architecture–based ASP.NET Core Web API that implements secure JWT authentication and role-based authorization.

## Features
- User Registration & Login
- JWT Authentication
- Role-Based Authorization
- Password Hashing
- Clean Architecture
- Repository Pattern
- DTO-based API responses
- Global Exception Handling

## Tech Stack
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT (Bearer Tokens)
- Clean Architecture

## Roles
- Admin
- User

## Authorization Example
```csharp
[Authorize(Roles = "Admin")]
public IActionResult GetEmployees()
