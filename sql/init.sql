CREATE DATABASE [Product]
GO
USE [Product];
GO
CREATE TABLE Categories (
                            Id BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY,
                            Name NVARCHAR(200) NOT NULL,
                            MinimumStock int NOT NULL,
                            MaximumStock int NOT NULL,
                            IsDeleted BIT DEFAULT 0 NOT NULL,
                            CreatedAt DATETIME NOT NULL,
                            UpdatedAt DATETIME NOT NULL,
);
GO
CREATE TABLE Products (
                          Id BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY,
                          CategoryId BIGINT NOT NULL,
                          Title NVARCHAR(200) NOT NULL,
                          Description NVARCHAR(max) NOT NULL,
                          StockQuantity int NOT NULL,
                          IsDeleted BIT DEFAULT 0 NOT NULL,
                          CreatedAt DATETIME NOT NULL,
                          UpdatedAt DATETIME NOT NULL,
                          CONSTRAINT FK_CategoryProduct FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);
GO
INSERT INTO [Categories] (Name, MinimumStock,MaximumStock,IsDeleted,CreatedAt,UpdatedAt)
VALUES 
('Elektronik', 50,200,0,GETDATE(),GETDATE()),
('Mobilya', 20,100,0,GETDATE(),GETDATE());
GO