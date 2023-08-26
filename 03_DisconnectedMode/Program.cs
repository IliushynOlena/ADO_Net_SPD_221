using _02_ConnectedModeCRUD;
using data_access;
using data_access.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Xml;

namespace _02_ConnectedModeCRUD
{
    #region Клaс Продукт
    //class Product
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string TypeProduct { get; set; }
    //    public int Quantity { get; set; }
    //    public int CostPrice { get; set; }
    //    public string Producer { get; set; }
    //    public int Price { get; set; }

    //}

    #endregion
    //class SportShopDb
    //{
    //    private SqlConnection connection;
    //    private string connectionString;
    //    public SportShopDb(string serverName, string DbName)
    //    {
    //        //DESKTOP-3HG9UVT\SQLEXPRESS   SportShop
    //        connectionString = $@"Data Source={serverName};
    //                          Initial Catalog={DbName};
    //                          Integrated Security=True;Connect Timeout=2;";
    //        connection = new SqlConnection(connectionString);
    //        connection.Open();
    //    }
    //    //public SportShopDb(string connectionString)
    //    //{
    //    //    connection = new SqlConnection(connectionString);
    //    //    connection.Open();
    //    //}
    //    ~SportShopDb()
    //    {
    //        connection.Close();
    //    }
    //    public void Create(Product product)
    //    {
    //        //string cmdText = $@"INSERT INTO Products
    //        //                VALUES ('{product.Name}', 
    //        //                        '{product.TypeProduct}', 
    //        //                         {product.Quantity}, 
    //        //                         {product.CostPrice}, 
    //        //                        '{product.Producer}', 
    //        //                         {product.Price})";
    //        string cmdText = $@"INSERT INTO Products
    //                                VALUES (@name, 
    //                                        @type, 
    //                                        @quantity, 
    //                                        @costPrice, 
    //                                        @producer, 
    //                                        @price)";
    //        SqlCommand command = new SqlCommand(cmdText, connection);
    //        command.Parameters.AddWithValue("name", product.Name);
    //        command.Parameters.AddWithValue("type", product.TypeProduct);
    //        command.Parameters.AddWithValue("quantity", product.Quantity);
    //        command.Parameters.AddWithValue("costPrice", product.CostPrice);
    //        command.Parameters.AddWithValue("producer", product.Producer);
    //        command.Parameters.AddWithValue("price", product.Price);

    //        command.CommandTimeout = 5;
    //        command.ExecuteNonQuery();
    //    }
    //    //public List<Product> GetAll()
    //    //{
    //    //    string cmdText = @"select * from Products";
    //    //    SqlCommand command = new SqlCommand(cmdText, connection);
    //    //    SqlDataReader reader = command.ExecuteReader();
    //    //    return this.GetProductsByQuery(reader);
    //    //}
    //    public List<Product> GetAll()
    //    {
    //        #region Execute Reader
    //        string cmdText = @"select * from Products";

    //        SqlCommand command = new SqlCommand(cmdText, connection);

    //        // ExecuteReader - виконує команду select та повертає результат у вигляді
    //        // DbDataReader
    //        SqlDataReader reader = command.ExecuteReader();

    //        Console.OutputEncoding = Encoding.UTF8;
    //        List<Product> products = new List<Product>();

    //        while (reader.Read())
    //        {
    //            products.Add(new Product()
    //            {
    //                Id = (int)reader[0],
    //                Name = (string)reader[1],
    //                TypeProduct = (string)reader[2],
    //                Quantity = (int)reader[3],
    //                CostPrice = (int)(reader[4]),
    //                Producer = (string)reader[5],
    //                Price = (int)(reader[6])
    //            });
    //        }
    //        reader.Close();
    //        #endregion
    //        return products;
    //    }
    //    public List<Product> GetAllByName(string name)
    //    {
    //        //'Ball; drop database SportShop; --'
    //        //SQL injection :name = 'Ball'; drop database SportShop;--
    //        //name = "Ball";
    //        //string cmdText = $@"select * from Products where Name = '{name}'";
    //        string cmdText = $@"select * from Products where Name = @name";
    //        SqlCommand command = new SqlCommand(cmdText, connection);
    //        command.Parameters.Add("name", System.Data.SqlDbType.NVarChar).Value = name;

    //        //SqlParameter sql = new SqlParameter()
    //        //{
    //        //    ParameterName = "name",
    //        //    SqlDbType = System.Data.SqlDbType.NVarChar,
    //        //    Value = name
    //        //};
    //        //command.Parameters.Add(sql);

    //        SqlDataReader reader = command.ExecuteReader();
    //        return this.GetProductsByQuery(reader);
    //    }
    //    private List<Product> GetProductsByQuery(SqlDataReader reader)
    //    {
    //        List<Product> products = new List<Product>();
    //        while (reader.Read())
    //        {
    //            products.Add(new Product()
    //            {
    //                Id = (int)reader[0],
    //                Name = (string)reader[1],
    //                TypeProduct = (string)reader[2],
    //                Quantity = (int)reader[3],
    //                CostPrice = (int)reader[4],
    //                Producer = (string)reader[5],
    //                Price = (int)reader[6]
    //            });
    //        }
    //        reader.Close();
    //        return products;
    //    }
    //    public void Update(Product product)
    //    {
    //        //string cmdText = $@"UPDATE Products
    //        //                  SET Name ='{product.Name}', 
    //        //                      TypeProduct ='{product.TypeProduct}', 
    //        //                      Quantity ={product.Quantity}, 
    //        //                      CostPrice ={product.CostPrice}, 
    //        //                      Producer ='{product.Producer}', 
    //        //                      Price ={product.Price}
    //        //                      where Id = {product.Id}";
    //        string cmdText = $@"UPDATE Products
    //                            SET Name = @name, 
    //                                TypeProduct = @type, 
    //                                Quantity = @quantity, 
    //                                CostPrice = @costPrice, 
    //                                Producer = @producer, 
    //                                Price = @price
    //                                where Id = {product.Id}";
    //        SqlCommand command = new SqlCommand(cmdText, connection);
    //        command.Parameters.AddWithValue("name", product.Name);
    //        command.Parameters.AddWithValue("type", product.TypeProduct);
    //        command.Parameters.AddWithValue("quantity", product.Quantity);
    //        command.Parameters.AddWithValue("costPrice", product.CostPrice);
    //        command.Parameters.AddWithValue("producer", product.Producer);
    //        command.Parameters.AddWithValue("price", product.Price);
    //        command.CommandTimeout = 5;
    //        command.ExecuteNonQuery();
    //    }
    //    public Product GetOneById(int id)
    //    {
    //        string cmdText = $@"select * from Products where Id = {id}";
    //        SqlCommand command = new SqlCommand(cmdText, connection);
    //        SqlDataReader reader = command.ExecuteReader();
    //        return this.GetProductsByQuery(reader).FirstOrDefault();
    //    }
    //    public void Delete(int id)
    //    {
    //        string cmdText = $@"Delete  Products WHERE Id = {id}";
    //        SqlCommand command = new SqlCommand(cmdText, connection);
    //        command.ExecuteNonQuery();
    //    }
    //}
    internal class Program
    {
        static void Main(string[] args)
        {
            SportShopDb db = new SportShopDb(@"DESKTOP-3HG9UVT\SQLEXPRESS", "SportShop");

            //SportShopDb db = new SportShopDb(@"LYKOV\SQLEXPRESS", "SportShop");
            //string con = @"Data Source = LYKOV\SQLEXPRESS; Initial Catalog = SportShop;
            //    Integrated Security = True; Connect Timeout = 2; ";
            //SportShopDb db = new SportShopDb(con);
            //Console.OutputEncoding = Encoding.UTF8;
            Product product = new Product()
            {
                Name = "Football sneakers",
                TypeProduct = "Sport Clothes",
                Quantity = 5,
                CostPrice = 3000,
                Producer = "Turkey",
                Price = 2000
            };
            //var pr = new Product()
            //{
            //    Name = "Lastu",
            //    TypeProduct = "Water equipment",
            //    Quantity = 5,
            //    CostPrice = 600,
            //    Producer = "China",
            //    Price = 800
            //};
            db.Create(product);
            //var products = db.GetAll();
            //foreach (var pr in products)
            //{
            //    Console.WriteLine(pr.Name);
            //}

            Console.WriteLine("Enter product name to search : ");
            string name = Console.ReadLine();
            List<Product> products = db.GetAllByName(name);
            foreach (var item in products)
            {
                Console.WriteLine(item.Id + " " + item.Name + " " + item.CostPrice + " " + item.Producer);
            }
            //var pr = db.GetAll();
            //foreach (var item in pr)
            //{
            //    Console.WriteLine(item.Id + " " + item.Name + " " + item.CostPrice + " " + item.Producer);
            //}


            Product p = db.GetOneById(27);
            Console.WriteLine(p.Id + " " + p.Name);

            p.Quantity = 100;
            p.CostPrice += 1500;
            p.Price += 2000;
            //p.Name = "Xaxaxaxxa';drop database SportShop;--";
            db.Update(p);
            //p = db.GetAll();
            //foreach (var item in p)
            //{
            //    Console.WriteLine(item.Id + " " + item.Name + " " + item.CostPrice + " " + item.Producer);
            //}

            // db.Delete(20);




        }
    }
}
/*
CREATE DATABASE SportShop
COLLATE Cyrillic_General_100_CI_AS;
GO

USE SportShop;
GO

--drop DATABASE SportShop;

--Товари: назва товару, вид товару (одяг, взуття, і т.д.), кількість товару в наявності, собівартість, виробник, ціна продажу
create table Products
(
  Id int identity(1,1) NOT NULL primary key,
  Name nvarchar(100) NOT NULL,
  TypeProduct nvarchar(20) NOT NULL,
  Quantity int NOT NULL,
  CostPrice int NOT NULL,
  Producer nvarchar(50),
  Price int NOT NULL
);
GO

INSERT INTO Products(Name, TypeProduct, Quantity, CostPrice, Producer, Price)
VALUES('Рукавиці', 'Аксесуари', 5, 85, 'Туреччина', 150),
    ('Окуляри', 'Аксесуари', 5, 85, 'Китай', 150),
    ('Ремінь', 'Одяг', 15, 120, 'Туреччина', 250),
    ('Рюкзак', 'Аксесуари', 10, 450, 'Польща', 700),
    ('Кросівки Адідас', 'Взуття', 20, 800, 'Польща', 1500)
GO

-- Працівники: повне ім'я, дата прийняття на роботу, стать, ЗП
CREATE TABLE Employees
(
  Id INT Identity(1, 1) NOT NULL PRIMARY KEY,
  FullName NVarchar(100) NOT NULL, Check(LEN(FullName) > 0),
  HireDate Date NOT NULL,
  Gender NVarchar(1)NOT NULL,
  Salary Money NOT NULL, Check(Salary > 0)
);
Go

INSERT INTO Employees(FullName, HireDate, Gender, Salary)
VALUES('Ярощук Іван Петрович', '2020-05-30', 'M', 8500),
('Михальчук Руслана Романівна', '2020-05-06', 'F', 8500),
('Левчук Тетяна Степанівна', '2020-05-07', 'F', 8500),
('Волос Ігор Іванович', '2020-05-15', 'M', 8500);
GO

-- Клієнти: повне ім'я, пошта, телефон, стать, знижка, підписка
CREATE TABLE Clients
(
  Id INT Identity(1, 1) NOT NULL PRIMARY KEY,
  FullName NVarchar(100) NOT NULL,
  Email NVarchar(100) NOT NULL,
  Phone NVarchar(15) NOT NULL,
  Gender NVarchar(1)NOT NULL,
  PercentSale INT NOT NULL CHECK(PercentSale >=0 AND PercentSale <=100) Default 0,
  Subscribe BIT Default 1
);
GO

INSERT INTO Clients(FullName, Email, Phone, Gender, PercentSale, Subscribe)
VALUES('Петрук Степан Романович', 'ss@c.com', '0971234567', 'M', 10, 0),
('Романчук Людмила Степанівна', 'rls@rr.org', '0989876543', 'F', 15, 1)
GO

-- Продажі: ціна продажі, кількість одениць товару, товар, клієнт (який виконав покупку), працівник (який виконав продажу)
CREATE TABLE Salles
(
  Id INT Identity(1, 1) NOT NULL PRIMARY KEY,
  ProductId INT References Products(Id) NOT NULL,
  Price Money NOT NULL,
  Quantity INT NOT NULL,
  EmployeeId INT References Employees(Id) NOT NULL,
  ClientId INT References Clients(Id) NOT NULL,
);
GO

INSERT INTO Salles(ProductId, Price, Quantity, EmployeeId, ClientId)
VALUES(1, 10000, 1, 1, 1),
    (1, 100, 1, 1, 1),
    (4, 1800, 1, 2, 2),
    (2, 10000, 3, 4, 2)
GO

 INSERT INTO Products
VALUES ('Shtanga', 'Equipment', 4, 3550, 'Ukraine', 3000);
select AVG(Price) from Products

--вивід значень з таблиць
SELECT * FROM Products;
SELECT* FROM Employees;
SELECT* FROM Clients;
SELECT* FROM Salles;

SELECT S.Id, P.Name AS Товар, C.FullName AS Клієнт, E.FullName AS Продавець,
S.Price AS Ціна, S.Quantity AS Кількість, S.Price* S.Quantity AS Сума--
FROM Salles S
JOIN Products P ON S.ProductId = P.Id
JOIN Employees E ON S.EmployeeId = E.Id
JOIN Clients C ON S.ClientId = C.Id
WHERE E.FullName = 'Михальчук Руслана Романівна';

SELECT S.Id, P.Name AS Товар, C.FullName AS Клієнт, E.FullName AS Продавець,
S.Price AS Ціна, S.Quantity AS Кількість, S.Price* S.Quantity AS Сума
FROM Salles S
JOIN Products P ON S.ProductId = P.Id
JOIN Employees E ON S.EmployeeId = E.Id
JOIN Clients C ON S.ClientId = C.Id
WHERE S.Price* S.Quantity > 1000;

SELECT C.FullName AS Клієнт,
       MIN(S.Price* S.Quantity) AS Найдешевша_покупка,
       MAX(S.Price * S.Quantity) AS Найдорожча_покупка
FROM Clients C
JOIN Salles S ON C.Id = S.ClientId
WHERE C.FullName = 'Петрук Степан Романович'
GROUP BY C.FullName;

SELECT C.FullName AS Клієнт,
       P.Name AS Назва_товару,
       MIN(S.Price* S.Quantity) AS Найдешевша_покупка,
       MAX(S.Price * S.Quantity) AS Найдорожча_покупка
FROM Clients C
JOIN Salles S ON C.Id = S.ClientId
JOIN Products P ON S.ProductId = P.Id
WHERE C.FullName = 'Петрук Степан Романович'
GROUP BY C.FullName, P.Name;
SELECT C.FullName AS Покупець,
       P.Name AS Назва_товару,
       S.Price AS Ціна_покупки,
       S.Quantity AS Кількість
FROM Clients C
JOIN Salles S ON C.Id = S.ClientId
JOIN Products P ON S.ProductId = P.Id
WHERE C.FullName = 'Петрук Степан Романович';


SELECT TOP 1 E.FullName AS Продавець,
       P.Name AS Назва_товару,
       S.Price AS Ціна_продажу,
       S.Quantity AS Кількість
FROM Employees E
JOIN Salles S ON E.Id = S.EmployeeId
JOIN Products P ON S.ProductId = P.Id
WHERE E.FullName = 'Ярощук Іван Петрович'
ORDER BY S.Id ASC;



-----------
--Triggers

select ClientId, SUM(Price * Quantity)
from Salles
group by ClientId
having SUM(Price * Quantity) > 50000

select Id, FullName, PercentSale
from Clients

select * from Salles

-- Task 5: При новій покупці товару потрібно перевіряти загальну суму покупок клієнта.
-- Якщо сума перевищила 50000 грн, необхідно встановити відсоток знижки в 15%
create or alter trigger tg_set_sale_to_client
on Salles
after insert
as
  declare @client_id int, @sale_id int;

select @client_id = ClientId, @sale_id = Id
  from inserted
    if (select SUM(Price * Quantity)
      from Salles
      where ClientId = @client_id) > 75000
    begin
      update Clients
      set PercentSale = 20
      where Id = @client_id

      update Salles
      set Price *= 0.8
      where Id = @sale_id
    end;



--drop trigger tg_set_sale_to_client2
create or alter trigger tg_add_sale_to_client2
on Salles
after insert
as
  declare @client_id int, @salle_id int;

--проходимося по всіх нових продажах
  -- зберігаючи id клієнта та id продажі
  select @client_id = ClientId, @salle_id = Id
  from inserted
    -- перевіряємо чи загальна сума продаж даного клієнта > 50000
    if (select SUM(Price * Quantity)
      from Salles
      where ClientId = @client_id) > 50000
    begin
      -- встановити даному клієнту знижку 15%
      update Clients
      set PercentSale = 15
      where Id = @client_id

      -- зменшуємо ціну даної продажі на 15%
      update Salles
      set Price *= 0.85
      where Id = @salle_id
    end;

--testing
select SUM(Price* Quantity)
from Salles
where ClientId = 1

insert Salles
values (2, 10000, 1, 2, 1)

SELECT* FROM Salles;

--deny insert existing products
create or alter trigger tg_deny_insert_exists_prod
on Products
after insert
as
  declare @name nvarchar(100);
declare @id int

  select @name = Name, @id = ID
  from inserted
    if exists (select Id
           from Products
           where Name = @name AND ID <> @id)
    begin
      raiserror('Can not insert existign product!', 4, 1);
rollback;
end;


INSERT INTO Products(Name, TypeProduct, Quantity, CostPrice, Producer, Price)
VALUES('Пальто', 'Одяг', 5, 85, 'Туреччина', 2300)

-- set sale to client
create or alter trigger tg_set_sale
on Salles
after insert
as
begin
  declare @Sale_Id INT
  declare @Client_Id INT

  select @Sale_Id = Id, @Client_Id = ClientId
  from inserted as i
  if 20000 < (select SUM(s.Price)
    from Salles as s
    where s.ClientId = @Client_Id)
  begin
    update Salles
    set Price = Price - (Price / 100 * 15)
    where Id = @Sale_Id
  end
end;
*/