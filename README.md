# TitanHelpDesk

TitanHelpDesk is a simple help desk ticket system I built as part of my final project for my software engineering course. The purpose of this project was to apply layered architecture concepts (Data, Application, and Presentation layers) using the .NET stack, while also following version control and testing best practices.

## Tech Stack

- .NET 6  
- Razor Pages for the UI  
- Entity Framework Core (Code First) for data access  
- SQLite as the development database  
- xUnit / MSTest and bUnit for testing

## Features

- Create new help desk tickets with validation  
- View all existing tickets in a table  
- Edit existing tickets  
- View ticket details on a separate page  
- Delete tickets from the list  
- Client-side and server-side validation  
- Basic styling and navigation

## Project Structure

- **Data Layer** – Contains the `Ticket` entity, enums, and the `ApplicationDbContext` using Entity Framework Core.  
- **Application Layer** – Handles business logic and CRUD operations.  
- **Presentation Layer** – Razor Pages for creating, listing, editing, and viewing tickets.  
- **Tests** – Model validation and basic Razor page tests.

## Testing

Unit tests were created to validate the `Ticket` model, including required fields, maximum lengths, and default values. Component tests using bUnit were also added to verify Razor Page behavior and validation messages.

## How to Run

1. Clone the repository.
2. Restore dependencies:
   ```bash
   dotnet restore
