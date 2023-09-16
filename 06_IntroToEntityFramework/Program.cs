using System;
using System.Linq;

namespace _06_IntroToEntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AirplaneDbContext context = new AirplaneDbContext();

            context.Clients.Add(
                new Client
                {
                    Name = "Volodia",
                    Birthdate = new DateTime(2006, 7, 8),
                    Email = "volodia@gmail.com"
                });

            context.SaveChanges();

            foreach (var client in context.Clients)
            {
                Console.WriteLine( $"Client :  {client.Name}. {client.Email} " +
                    $"{client.Birthdate.ToShortDateString()}");
            }

            //context.Airplanes.Select(i => i.Model);
        }
    }
}
