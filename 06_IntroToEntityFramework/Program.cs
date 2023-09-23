using System;
using System.Linq;

namespace _06_IntroToEntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AirplaneDbContext context = new AirplaneDbContext();

            //Linq to Entities
            var filteredFlights = context.Flights
                .Where(f => f.ArrivalCity == "Lviv")
                .OrderBy(f => f.DepartureCity);

            foreach (var f in filteredFlights)
            {
                Console.WriteLine($"Flight :  {f.Number}. From {f.DepartureCity} " +
                    $" to {f.ArrivalCity}");
            }


            //context.Clients.Add(
            //    new Client
            //    {
            //        Name = "Volodia",
            //        Birthdate = new DateTime(2006, 7, 8),
            //        Email = "volodia@gmail.com"
            //    });

            //context.SaveChanges();

            //foreach (var client in context.Clients)
            //{
            //    Console.WriteLine( $"Client :  {client.Name}. {client.Email} " +
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
