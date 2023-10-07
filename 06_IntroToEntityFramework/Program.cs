using _06_IntroToEntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;

namespace _06_IntroToEntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AirplaneDbContext context = new AirplaneDbContext();
            //Loading data : Include(relating data)
            
            var flights = context.Flights
                .Include(f=>f.Airplane)//Like JOIN operator in SQL
                .Include(f=>f.Clients)//Like JOIN operator in SQL
                .OrderBy(f => f.DepartureTime);
            foreach (var f in flights)
            {
                Console.WriteLine($"Flight :  {f.Number}. From {f.DepartureCity} " +
                    $" to {f.ArrivalCity}.\nTime : {f.DepartureTime}\nId Airplane : {f.AirplaneId}" +
                    $" Model Airplane {f.Airplane?.Model}\nCount clients {f.Clients.Count } \n");
                Console.WriteLine("List of clients : ");
                foreach (var c in f.Clients)
                {
                    Console.WriteLine($" {c.Name}  {c.Phone}  {c.Email}");
                }
                Console.WriteLine("___________________________________________\n");
            }

            var client = context.Clients.Find(1);
            context.Entry(client).Collection(c => c.Flights).Load();
            Console.WriteLine($"Client : {client.Name} has {client.Flights.Count} flights");

            foreach (var f in client.Flights)
            {
                Console.WriteLine($" From {f.DepartureCity}  to {f.ArrivalCity}");
            }
            //Linq to Entities
            //var filteredFlights = context.Flights
            //    .Where(f => f.ArrivalCity == "Lviv")
            //    .OrderBy(f => f.DepartureCity);
            

            //foreach (var f in filteredFlights)
            //{
            //    Console.WriteLine($"Flight :  {f.Number}. From {f.DepartureCity} " +
            //        $" to {f.ArrivalCity}  Id Airplane : {f.AirplaneId}");
            //}

            int a = 0;
            int? b = null;

            //context.Clients.Add(
            //    new Client
            //    {
            //        Name = "Olena",
            //        Birthdate = new DateTime(2006, 7, 8),
            //        Email = "ilena@gmail.com",
            //        Phone = "38056454564"
                     
            //    });

            //context.SaveChanges();

            //foreach (var client in context.Clients)
            //{
            //    Console.WriteLine($"Client :  {client.Name}. {client.Email} " +
            //        $"{client.Birthdate}");
            //}

            //context.Airplanes.Select(i => i.Model);
        }

        ////string name = null;
        //Nullable<int> a = null;
        //int ?b = null;
        ////int b = 0;
        //Client cl = null;
        //Client ?cl1 = 0;
    }
}
