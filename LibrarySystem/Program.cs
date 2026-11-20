using LibrarySystem.Data;
using Microsoft.EntityFrameworkCore;

var options = new DbContextOptionsBuilder<LibraryContext>()
    .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=DEPI_LibraryDB;Trusted_Connection=True;TrustServerCertificate=True;")
    .Options;

using var context = new LibraryContext(options);
context.Database.EnsureCreated();
Console.WriteLine("Library database is ready.");
