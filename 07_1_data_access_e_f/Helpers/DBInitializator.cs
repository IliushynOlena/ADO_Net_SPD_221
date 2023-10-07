using _06_IntroToEntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _06_IntroToEntityFramework.Helpers
{
    internal static class DBInitializator
    {

        public static void SeedAirplane(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airplane>().HasData(new Airplane[]
          {
                new Airplane()
                {
                     Id = 1,
                     Model = "Boing 747",
                     MaxPassangers = 100
                },
                new Airplane()
                {
                     Id = 2,
                     Model = "AN 125",
                     MaxPassangers = 125
                },
                new Airplane()
                {
                     Id = 3,
                     Model = "F16",
                     MaxPassangers = 1
                }
          });
        }
        public static void SeedFlights(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>().HasData(new Flight[]
            {
                new Flight()
                {
                     Number = 1,
                     DepartureCity = "Rivne",
                     ArrivalCity = "Lviv",
                     ArrivalTime = new DateTime(2023,5,7,13,30,30),
                     DepartureTime = new DateTime(2023,5,7,7,25,25),
                     AirplaneId = 1
                },
                 new Flight()
                {
                     Number = 2,
                     DepartureCity = "Warshav",
                     ArrivalCity = "Lviv",
                     ArrivalTime = new DateTime(2023,6,17,15,30,30),
                     DepartureTime = new DateTime(2023,6,17,6,25,25),
                     AirplaneId = 2
                }
            });

        }
    }
}
