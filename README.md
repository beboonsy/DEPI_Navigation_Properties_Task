# DEPI – Navigation Properties Assignment

This folder contains three independent .NET 8 console projects using Entity Framework Core 8 and SQL Server.

## Projects
1. ECommerceSystem – Category/Product (one-to-many), Customer/Order (one-to-many), and Order/Product through OrderDetail (many-to-many).
2. LibrarySystem – Author/Book (one-to-many), and Book/Borrower through Loan (many-to-many).
3. HealthCareSystem – Patient/Doctor through Appointment (many-to-many).

## How to run
- Open a project folder in Visual Studio.
- Restore NuGet packages.
- Ensure SQL Server LocalDB is installed (or replace the connection string in Program.cs with your SQL Server connection string).
- Set the project as Startup Project and run it.
- Each project calls `EnsureCreated()` to create its database if it does not exist.

## Important mapping notes
- `ICollection<T>` properties are collection navigation properties.
- Entity-reference properties such as `Product.Category` are reference navigation properties.
- Join entities (`OrderDetail`, `Loan`, and `Appointment`) are explicitly modeled because the assignment requires extra data on the relationship (Quantity, LoanDate/ReturnDate, AppointmentDate).
- Composite primary keys are configured for the join entities. For Loan and Appointment, the date is included so the same pair can be related more than once at different times.

## Database diagram screenshots
The three PNG files in the root folder are ER-style database diagrams showing primary keys, foreign keys, and relationship cardinalities. After creating the databases in SQL Server, you can also use SSMS Database Diagrams to create native screenshots.

## LinkedIn article
Navigation Properties in Entity Framework Core — Why They Matter:
https://www.linkedin.com/pulse/navigation-properties-entity-framework-core-why-matter-omar-yosrii-yznbf

## Official reference
Microsoft Learn – EF Core relationship navigations:
https://learn.microsoft.com/en-us/ef/core/modeling/relationships/navigations
