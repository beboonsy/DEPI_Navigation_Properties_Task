CREATE DATABASE DEPI_ECommerceDB;
GO
USE DEPI_ECommerceDB;
GO

CREATE TABLE Categories (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE Customers (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(150) NOT NULL
);
GO

CREATE TABLE Products (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(150) NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    CategoryId INT NOT NULL,
    CONSTRAINT FK_Products_Categories
        FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);
GO

CREATE TABLE Orders (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    OrderDate DATETIME2 NOT NULL,
    CustomerId INT NOT NULL,
    CONSTRAINT FK_Orders_Customers
        FOREIGN KEY (CustomerId) REFERENCES Customers(Id)
);
GO

CREATE TABLE OrderDetails (
    OrderId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    CONSTRAINT PK_OrderDetails PRIMARY KEY (OrderId, ProductId),
    CONSTRAINT FK_OrderDetails_Orders
        FOREIGN KEY (OrderId) REFERENCES Orders(Id),
    CONSTRAINT FK_OrderDetails_Products
        FOREIGN KEY (ProductId) REFERENCES Products(Id)
);
GO
