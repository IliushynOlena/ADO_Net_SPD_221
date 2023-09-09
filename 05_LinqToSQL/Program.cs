using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_LinqToSQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            ShopClassesDataContext dbContext = new ShopClassesDataContext();
            //CRUD Interface - Create Read Update Delete
            //Read
            var products = dbContext.Products;
            foreach (var p in products)
            {
                Console.WriteLine($"Product : {p.Id}. {p.Name}. {p.Price}$");
            }

            Console.WriteLine("-------------------------------");

            var product = dbContext.Products
                        .Where(p => p.Price > 500)
                        .OrderByDescending(p => p.Price).Take(5);
            foreach (var p in product)
            {
                Console.WriteLine($"Product : {p.Id}. {p.Name}. {p.Price}$");
            }
            Console.WriteLine("-------------------------------");
            product = (from p in dbContext.Products
                      where p.Price > 500
                      orderby p.Price descending
                      select p).Take(5);
            foreach (var p in product)
            {
                Console.WriteLine($"Product : {p.Id}. {p.Name}. {p.Price}$");
            }
            //Create
            var sportBottle = new Product()
            {
                Name = "Termos",
                CostPrice = 500,
                Price = 600,
                Producer = "China",
                Quantity = 22,
                TypeProduct = "Acessories"
            };
            //dbContext.Products.InsertOnSubmit(sportBottle);//save to collection


            //dbContext.SubmitChanges();//save to database
            //Update
            //var productToEdit = dbContext.Products.Where(p => p.Id == 2).FirstOrDefault();
            var productToEdit = dbContext.Products.FirstOrDefault(p => p.Id == 2);
            productToEdit.CostPrice = 400;
            productToEdit.Price = 500;

            //dbContext.SubmitChanges();
            //Delete
            var productToDelete = dbContext.Products.FirstOrDefault(p => p.Id == 43);
            if(productToDelete != null)
                dbContext.Products.DeleteOnSubmit(productToDelete);

            dbContext.SubmitChanges();


        }
    }
}
