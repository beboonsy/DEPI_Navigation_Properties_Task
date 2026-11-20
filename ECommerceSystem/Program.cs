using ECommerceSystem.Data;
using Microsoft.EntityFrameworkCore;

var options = new DbContextOptionsBuilder<ECommerceContext>()
    .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=DEPI_ECommerceDB;Trusted_Connection=True;TrustServerCertificate=True;")
    .Options;

using var context = new ECommerceContext(options);
context.Database.EnsureCreated();
Console.WriteLine("E-Commerce database is ready.");
