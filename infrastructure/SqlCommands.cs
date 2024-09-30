namespace infrastructure;

public class SqlCommands
{
    // Connection string
    public const string ConnectionString =
        "Server=localhost;Port=5432;Database=order_managment_db;User Id=postgres;Password=01062007;";

    // Customer queries
    public const string GetAllCustomers = "SELECT * FROM customers";
    public const string GetCustomerById = "SELECT * FROM customers WHERE id = @id";
    public const string AddCustomer = "INSERT INTO customers (fullname, email, phone, createdat) VALUES (@fullname, @email, @phone, @createdat)";
    public const string UpdateCustomer = "UPDATE customers SET fullname = @fullname, email = @email, phone = @phone, createdat = @createdat WHERE id = @id";
    public const string DeleteCustomer = "DELETE FROM customers WHERE id = @id";

    // Product queries
    public const string GetAllProducts = "SELECT * FROM products";
    public const string GetProductById = "SELECT * FROM products WHERE id = @id";
    public const string AddProduct = "INSERT INTO products (name, price, stockquantity, createdat) VALUES (@name, @price, @stockquantity, @createdat)";
    public const string UpdateProduct = "UPDATE products SET name = @name, price = @price, stockquantity = @stockquantity, createdat = @createdat WHERE id = @id";
    public const string DeleteProduct = "DELETE FROM products WHERE id = @id";

    // Order queries
    public const string GetAllOrders = "SELECT * FROM orders";
    public const string GetOrderById = "SELECT * FROM orders WHERE id = @id";
    public const string AddOrder = "INSERT INTO orders (customerid, totalamount, orderdate, status, createdat) VALUES (@customerid, @totalamount, @orderdate, @status, @createdat)";
    public const string UpdateOrder = "UPDATE orders SET customerid = @customerid, totalamount = @totalamount, orderdate = @orderdate, status = @status, createdat = @createdat WHERE id = @id";
    public const string DeleteOrder = "DELETE FROM orders WHERE id = @id";

    // OrderItem queries
    public const string GetAllOrderItems = "SELECT * FROM orderitems";
    public const string GetOrderItemById = "SELECT * FROM orderitems WHERE id = @id";
    public const string AddOrderItem = "INSERT INTO orderitems (orderid, productid, quantity, price, createdat) VALUES (@orderid, @productid, @quantity, @price, @createdat)";
    public const string UpdateOrderItem = "UPDATE orderitems SET orderid = @orderid, productid = @productid, quantity = @quantity, price = @price, createdat = @createdat WHERE id = @id";
    public const string DeleteOrderItem = "DELETE FROM orderitems WHERE id = @id";

    // Queries
    public const string GetOrderByCustomerId = "SELECT * FROM orders WHERE customerid = @customerid AND orderdate BETWEEN @StartDate AND @EndDate";
    public const string GetAllProductsZero = "SELECT * FROM products WHERE stockquantity = 0";
    public const string GetCustomerStatistics = @"
        SELECT c.id, c.fullname, c.email, c.phone, c.createdat, 
               COUNT(o.id) AS countoforders, SUM(o.totalamount) AS sum
        FROM customers c 
        JOIN orders o ON c.id = o.customerid 
        GROUP BY c.id, c.fullname, c.email, c.phone, c.createdat";
    public const string GetProductByOrderId = @"
        SELECT p.id AS Id, p.name AS Name, p.price AS Price, p.stockquantity, p.createdat AS CreatedAt 
        FROM products p 
        JOIN orderitems oi ON oi.productid = p.id 
        WHERE oi.orderid = @OrderId";
    public const string GetOrdersByStatusAndDate = @"
        SELECT id, customerid, totalamount, orderdate, status, createdat 
        FROM orders 
        WHERE status = @Status AND orderdate BETWEEN @StartDate AND @EndDate";
    public const string GetPopularProduct = @"
        SELECT p.id AS Id, p.name AS Name, p.price AS Price, p.stockquantity AS StockQuantity, p.createdat AS CreatedAt, 
               SUM(oi.quantity) AS TotalSales 
        FROM products p 
        JOIN orderitems oi ON p.id = oi.productid 
        GROUP BY p.id 
        ORDER BY TotalSales DESC 
        LIMIT 1";
    public const string GetSalesStatistics = @"
        SELECT COUNT(id) AS TotalOrders, COALESCE(SUM(totalamount), 0) AS TotalSales 
        FROM orders 
        WHERE EXTRACT(MONTH FROM orderdate) = @Month AND EXTRACT(YEAR FROM orderdate) = @Year";
    public const string GetInactiveCustomers = @"
        SELECT c.id, c.fullname, c.email, c.phone, c.createdat 
        FROM customers c 
        LEFT JOIN orders o ON c.id = o.customerid 
        WHERE o.orderdate IS NULL OR o.orderdate < (CURRENT_DATE - INTERVAL '1 year')";
    public const string GetOrdersByProductId = @"
        SELECT o.id AS Id, o.customerid AS CustomerId, o.totalamount AS TotalAmount, o.orderdate AS OrderDate, o.status AS Status, o.createdat AS CreatedAt 
        FROM orders o 
        JOIN orderitems oi ON o.id = oi.orderid 
        WHERE oi.productid = @ProductId";
    public const string GetProductsSummary = @"
        SELECT p.id AS Id, p.name AS Name, p.price AS Price, p.stockquantity AS StockQuantity, p.createdat AS CreatedAt, 
               COALESCE(SUM(oi.quantity), 0) AS TotalQuantitySold, COALESCE(SUM(oi.price * oi.quantity), 0) AS TotalSales 
        FROM products p 
        JOIN orderitems oi ON p.id = oi.productid 
        GROUP BY p.id, p.name, p.price, p.stockquantity, p.createdat";
}
