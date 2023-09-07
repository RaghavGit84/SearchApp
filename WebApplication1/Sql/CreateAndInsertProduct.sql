-- Create a stored procedure to create a table and insert 10 dummy values
CREATE PROCEDURE CreateAndPopulateProductTable
AS
BEGIN
    -- Create the Product table if it doesn't exist
    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ProductModels')
    BEGIN
        CREATE TABLE ProductModels
        (
            ProductID INT PRIMARY KEY,
            ProductName NVARCHAR(255),
            Size NVARCHAR(50),
            Price DECIMAL(18, 2),
            MfgDate DATE,
            Category NVARCHAR(50)
        )
    END

    -- Insert 10 dummy values into the Product table
    INSERT INTO ProductModels ( ProductName, Size, Price, MfgDate, Category)
    VALUES
        ( 'Product 1', 'Small', 10.99, '2023-01-15', 'Category A'),
        ( 'Product 2', 'Medium', 19.99, '2023-02-10', 'Category B'),
        ( 'Product 3', 'Large', 29.99, '2023-03-20', 'Category A'),
        ( 'Product 4', 'Small', 14.99, '2023-04-05', 'Category C'),
        ( 'Product 5', 'Medium', 24.99, '2023-05-12', 'Category B'),
        ( 'Product 6', 'Large', 34.99, '2023-06-25', 'Category A'),
        ( 'Product 7', 'Small', 12.99, '2023-07-18', 'Category C'),
        ( 'Product 8', 'Medium', 22.99, '2023-08-03', 'Category B'),
        ( 'Product 9', 'Large', 32.99, '2023-09-14', 'Category A'),
        ( 'Product 10', 'Small', 15.99, '2023-10-30', 'Category C')
END

