
# Order Management API

Order Management API - это RESTful API для управления заказами, продуктами, клиентами и элементами заказов. Проект реализован на ASP.NET Core с использованием PostgreSQL и Dapper для взаимодействия с базой данных.

## Установка и настройка

### 1. Клонирование репозитория
```bash
git clone https://github.com/your-repo/order-management-api.git
```

### 2. Настройка базы данных
Убедитесь, что PostgreSQL установлен и настроен. Создайте базу данных `order_managment_db` и обновите строку подключения в проекте:

```csharp
public const string ConnectionString = "Server=localhost;Port=5432;Database=order_managment_db;User Id=postgres;Password=your_password;";
```

### 3. Настройка таблиц
Создайте необходимые таблицы в базе данных, используя SQL-запросы с Migrations.sql


### 4. Запуск проекта
Запустите проект с помощью следующей команды:

```bash
dotnet run
```

API будет доступно по адресу `https://localhost:5555`.

### 5. Swagger документация
Для доступа к Swagger перейдите по адресу:

```
https://localhost:5555/swagger
```

## Основные Endpoints

 - **GET /api/customers** - Получить всех клиентов
  - **POST /api/customers** - Создать клиента
  - **GET /api/customers/{id}** - Получить клиента по ID
  - **PUT /api/customers/{id}** - Обновить клиента
  - **DELETE /api/customers/{id}** - Удалить клиента
  - **GET /api/products** - Получить все продукты
  - **POST /api/products** - Создать продукт
  - **GET /api/products/{id}** - Получить продукт по ID
  - **PUT /api/products/{id}** - Обновить продукт
  - **DELETE /api/products/{id}** - Удалить продукт
  - **GET /api/orders** - Получить все заказы
  - **POST /api/orders** - Создать заказ
  - **GET /api/orders/{id}** - Получить заказ по ID
  - **PUT /api/orders/{id}** - Обновить заказ
  - **DELETE /api/orders/{id}** - Удалить заказ
  - **GET /api/orderitems** - Получить все элементы заказа
  - **POST /api/orderitems** - Создать элемент заказа
  - **GET /api/orderitems/{id}** - Получить элемент заказа по ID
  - **PUT /api/orderitems/{id}** - Обновить элемент заказа
  - **DELETE /api/orderitems/{id}** - Удалить элемент заказа
  - **GET /api/customers/orders?startDate={startDate}&endDate={endDate}** - Получить клиентов с их заказами за указанный период
  - **GET /api/products/out-of-stock** - Получить продукты с нулевым количеством на складе
  - **GET /api/customers/statistics** - Получить статистику по каждому клиенту (общее количество заказов и сумма)
  - **GET /api/orders/details** - Получить все заказы с информацией о клиентах и товарах
  - **GET /api/orders?status={status}&startDate={startDate}&endDate={endDate}** - Получить заказы по статусу и дате
  - **GET /api/products/popular** - Получить самый популярный продукт по количеству продаж
  - **GET /api/orders/sales-statistics?month={month}&year={year}** - Получить статистику по продажам за указанный месяц
  - **GET /api/customers/inactive** - Получить неактивных клиентов (которые не делали заказы более года)
  - **GET /api/products/{productId}/orders** - Получить все заказы для конкретного продукта
  - **GET /api/orders/products-summary** - Получить сводную информацию о заказах с общей суммой по каждому продукту
 - **
