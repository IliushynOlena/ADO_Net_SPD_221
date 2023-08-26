using data_access.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace data_access
{
    public  class SportShopDb
    {
        private SqlConnection connection;
        private string connectionString;
        public SportShopDb(string serverName, string DbName)
        {
            //DESKTOP-3HG9UVT\SQLEXPRESS   SportShop
            connectionString = $@"Data Source={serverName};
                              Initial Catalog={DbName};
                              Integrated Security=True;Connect Timeout=2;";
            connection = new SqlConnection(connectionString);
            connection.Open();
        }
        //public SportShopDb(string connectionString)
        //{
        //    connection = new SqlConnection(connectionString);
        //    connection.Open();
        //}
        ~SportShopDb()
        {
            connection.Close();
        }
        public void Create(Product product)
        {
            //string cmdText = $@"INSERT INTO Products
            //                VALUES ('{product.Name}', 
            //                        '{product.TypeProduct}', 
            //                         {product.Quantity}, 
            //                         {product.CostPrice}, 
            //                        '{product.Producer}', 
            //                         {product.Price})";
            string cmdText = $@"INSERT INTO Products
                                    VALUES (@name, 
                                            @type, 
                                            @quantity, 
                                            @costPrice, 
                                            @producer, 
                                            @price)";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.Parameters.AddWithValue("name", product.Name);
            command.Parameters.AddWithValue("type", product.TypeProduct);
            command.Parameters.AddWithValue("quantity", product.Quantity);
            command.Parameters.AddWithValue("costPrice", product.CostPrice);
            command.Parameters.AddWithValue("producer", product.Producer);
            command.Parameters.AddWithValue("price", product.Price);

            command.CommandTimeout = 5;
            command.ExecuteNonQuery();
        }
        //public List<Product> GetAll()
        //{
        //    string cmdText = @"select * from Products";
        //    SqlCommand command = new SqlCommand(cmdText, connection);
        //    SqlDataReader reader = command.ExecuteReader();
        //    return this.GetProductsByQuery(reader);
        //}
        public List<Product> GetAll()
        {
            #region Execute Reader
            string cmdText = @"select * from Products";

            SqlCommand command = new SqlCommand(cmdText, connection);

            // ExecuteReader - виконує команду select та повертає результат у вигляді
            // DbDataReader
            SqlDataReader reader = command.ExecuteReader();

           // Console.OutputEncoding = Encoding.UTF8;
            List<Product> products = new List<Product>();

            while (reader.Read())
            {
                products.Add(new Product()
                {
                    Id = (int)reader[0],
                    Name = (string)reader[1],
                    TypeProduct = (string)reader[2],
                    Quantity = (int)reader[3],
                    CostPrice = (int)(reader[4]),
                    Producer = (string)reader[5],
                    Price = (int)(reader[6])
                });
            }
            reader.Close();
            #endregion
            return products;
        }
        public List<Product> GetAllByName(string name)
        {
            //'Ball; drop database SportShop; --'
            //SQL injection :name = 'Ball'; drop database SportShop;--
            //name = "Ball";
            //string cmdText = $@"select * from Products where Name = '{name}'";
            string cmdText = $@"select * from Products where Name = @name";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.Parameters.Add("name", System.Data.SqlDbType.NVarChar).Value = name;

            //SqlParameter sql = new SqlParameter()
            //{
            //    ParameterName = "name",
            //    SqlDbType = System.Data.SqlDbType.NVarChar,
            //    Value = name
            //};
            //command.Parameters.Add(sql);

            SqlDataReader reader = command.ExecuteReader();
            return this.GetProductsByQuery(reader);
        }
        private List<Product> GetProductsByQuery(SqlDataReader reader)
        {
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                products.Add(new Product()
                {
                    Id = (int)reader[0],
                    Name = (string)reader[1],
                    TypeProduct = (string)reader[2],
                    Quantity = (int)reader[3],
                    CostPrice = (int)reader[4],
                    Producer = (string)reader[5],
                    Price = (int)reader[6]
                });
            }
            reader.Close();
            return products;
        }
        public void Update(Product product)
        {
            //string cmdText = $@"UPDATE Products
            //                  SET Name ='{product.Name}', 
            //                      TypeProduct ='{product.TypeProduct}', 
            //                      Quantity ={product.Quantity}, 
            //                      CostPrice ={product.CostPrice}, 
            //                      Producer ='{product.Producer}', 
            //                      Price ={product.Price}
            //                      where Id = {product.Id}";
            string cmdText = $@"UPDATE Products
                                SET Name = @name, 
                                    TypeProduct = @type, 
                                    Quantity = @quantity, 
                                    CostPrice = @costPrice, 
                                    Producer = @producer, 
                                    Price = @price
                                    where Id = {product.Id}";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.Parameters.AddWithValue("name", product.Name);
            command.Parameters.AddWithValue("type", product.TypeProduct);
            command.Parameters.AddWithValue("quantity", product.Quantity);
            command.Parameters.AddWithValue("costPrice", product.CostPrice);
            command.Parameters.AddWithValue("producer", product.Producer);
            command.Parameters.AddWithValue("price", product.Price);
            command.CommandTimeout = 5;
            command.ExecuteNonQuery();
        }
        public Product GetOneById(int id)
        {
            string cmdText = $@"select * from Products where Id = {id}";
            SqlCommand command = new SqlCommand(cmdText, connection);
            SqlDataReader reader = command.ExecuteReader();
            return this.GetProductsByQuery(reader).FirstOrDefault();
        }
        public void Delete(int id)
        {
            string cmdText = $@"Delete  Products WHERE Id = {id}";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.ExecuteNonQuery();
        }
    }
}
