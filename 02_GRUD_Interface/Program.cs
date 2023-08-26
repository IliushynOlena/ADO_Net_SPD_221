using System.Data.SqlClient;
using System.Text;

namespace _02_GRUD_Interface
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public float CostPrice { get; set; }
        public string Producer { get; set; }
        public float Price { get; set; }
    }
    class SportShopDb
    {
        //CRUD Interface
        //[C]reate
        //[R]ead
        //[U]pdate
        //[D]elete

        private SqlConnection connection;
        private string connectionString;
        public SportShopDb(string serverName, string DbName )
        {
            //DESKTOP-3HG9UVT\SQLEXPRESS   SportShop
            connectionString = $@"Data Source={serverName};
                              Initial Catalog={DbName};
                              Integrated Security=True;Connect Timeout=2;";
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public void Create(Product product)
        {
            string cmdText = $@"INSERT INTO Products
                              VALUES ('{product.Name}', 
                                      '{product.Type}', 
                                      {product.Quantity}, 
                                      {product.CostPrice}, 
                                      '{product.Producer}', 
                                      {product.Price})";

            SqlCommand command = new SqlCommand(cmdText, connection);
            command.CommandTimeout = 5; // default - 30sec

            command.ExecuteNonQuery();
        }
        public List<Product> GetAll()
        {
            #region Execute Reader
            string cmdText = @"select * from Products";

            SqlCommand command = new SqlCommand(cmdText, connection);

            // ExecuteReader - виконує команду select та повертає результат у вигляді
            // DbDataReader
            SqlDataReader reader = command.ExecuteReader();

            Console.OutputEncoding = Encoding.UTF8;
            List<Product> products = new List<Product>();   

            while (reader.Read())
            {
                products.Add(new Product()
                {
                    Id = (int)reader[0],
                    Name = (string)reader[1],
                    Type = (string)reader[2],
                    Quantity = (int)reader[3],
                    CostPrice = Convert.ToSingle(reader[4]),
                    Producer = (string)reader[5],
                    Price = Convert.ToSingle(reader[6])
                });
            }

            reader.Close();
            #endregion
            return products;
        }
        public void Update(Product product)
        {
          
            string cmdText = $@"UPDATE Products
                              SET Name ='{product.Name}', 
                                  TypeProduct ='{product.Type}', 
                                  Quantity ={product.Quantity}, 
                                  CostPrice ={product.CostPrice}, 
                                  Producer ='{product.Producer}', 
                                  Price ={product.Price}
                                  where Id = {product.Id}";

            SqlCommand command = new SqlCommand(cmdText, connection);
            command.CommandTimeout = 5; // default - 30sec

            command.ExecuteNonQuery();

        }
        public void Delete(int id)
        {
            string cmdText = $"delete Products where Id = {id}";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.ExecuteNonQuery();

        }
        public Product GetOne(int id)
        {
            #region Execute Reader
            string cmdText = $@"select * from Products where Id = {id}";

            SqlCommand command = new SqlCommand(cmdText, connection);

            SqlDataReader reader = command.ExecuteReader();

            Console.OutputEncoding = Encoding.UTF8;
            Product product = new Product();

            while (reader.Read())
            {

                product.Id = (int)reader[0];
                product.Name = (string)reader[1];
                product.Type = (string)reader[2];
                product.Quantity = (int)reader[3];
                product.CostPrice = Convert.ToSingle(reader[4]);
                product.Producer = (string)reader[5];
                product.Price = Convert.ToSingle(reader[6]);
           
            }

            reader.Close();
            #endregion
            return product;
        }
        public List<Product> GetByName(string name)
        {
            #region Execute Reader
            string cmdText = $@"select * from Products where Name = '{name}'";

            SqlCommand command = new SqlCommand(cmdText, connection);

            SqlDataReader reader = command.ExecuteReader();

            Console.OutputEncoding = Encoding.UTF8;
            List<Product> products = new List<Product>();

            while (reader.Read())
            {
                products.Add(new Product()
                {
                    Id = (int)reader[0],
                    Name = (string)reader[1],
                    Type = (string)reader[2],
                    Quantity = (int)reader[3],
                    CostPrice = Convert.ToSingle(reader[4]),
                    Producer = (string)reader[5],
                    Price = Convert.ToSingle(reader[6])
                });
            }

            reader.Close();
            #endregion
            return products;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Тут я створюю SportShopDb і додаю товари в базу
            SportShopDb db = new SportShopDb(@"DESKTOP-3HG9UVT\SQLEXPRESS", "SportShop");
            var pr = new Product()
            {
                Name = "Lastu",
                Type = "Water equipment",
                Quantity = 5,
                CostPrice = 600,
                Producer = "China",
                Price = 800
            };
            //db.Create(pr);
            var products = db.GetAll();
            foreach (var product in products)
            {
                Console.WriteLine(product.Name);
            }

            Product res = db.GetOne(5);
            Console.WriteLine("Product : " + res.Name);
            res.CostPrice = 3000;
            res.Price = 3500;
            //db.Update(res);

            //db.Delete(40);
            #endregion
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Enter product Name to search : ");
            string name = Console.ReadLine();
            products = db.GetByName(name);
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name} {product.Price}  {product.Producer}");
            }



        }
    }
}