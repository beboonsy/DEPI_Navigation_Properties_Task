using HealthCareSystem.Data;
using Microsoft.EntityFrameworkCore;

var options = new DbContextOptionsBuilder<HealthCareContext>()
    .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=DEPI_HealthCareDB;Trusted_Connection=True;TrustServerCertificate=True;")
    .Options;

using var context = new HealthCareContext(options);
context.Database.EnsureCreated();
Console.WriteLine("Health Care database is ready.");
