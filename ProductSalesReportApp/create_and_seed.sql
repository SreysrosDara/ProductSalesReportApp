

CREATE TABLE ProductSales (
    Id INT IDENTITY PRIMARY KEY,
    ProductCode NVARCHAR(10),
    ProductName NVARCHAR(100),
    Quantity INT,
    UnitPrice DECIMAL(10, 2),
    SaleDate DATE
);

INSERT INTO ProductSales (ProductCode, ProductName, Quantity, UnitPrice, SaleDate) VALUES
('P001', 'Pen', 10, 1.50, '2025-06-20'),
('P001', 'Pen', 5, 1.50, '2025-06-25'),
('P002', 'Notebook', 3, 3.20, '2025-06-21'),
('P003', 'Eraser', 15, 0.80, '2025-06-22');
