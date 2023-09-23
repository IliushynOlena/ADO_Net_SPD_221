using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_IntroToEntityFramework
{
    [Table("Passangers")]
    //Entities

    public class Client
    {
        //properties
        //Primary key naming : Id/id/ID/ EntityName+Id(ClientId)
        public int Id { get; set; }
        [Required]//null - not null
        [MaxLength(100)]//nvarchar(max) - nvarchar(100)
        [Column("FirstName")]//set column name
        public string Name { get; set; }
        [Required, MaxLength(100)]
        //[EmailAddress]
        public string Email { get; set; }
        //public Nullable< DateTime> Birthdate { get; set; }//not null- ? null
        public DateTime ?Birthdate { get; set; }//not null- ? null

        //Relationship type
        public ICollection<Flight> Flights { get; set; }

    }
    public class Airplane
    {
        //properties
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Model { get; set; }
        public int MaxPassangers { get; set; }
        //Relationship type
        public ICollection<Flight> Flights { get; set; }
    }
    public class Flight
    {
        //properties
        //public int Id { get; set; }
        //Primary key naming : Id/id/ID/ EntityName+Id(ClientId)
        [Key]//Primary key
        public int Number { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        [Required, MaxLength(100)]
        public string DepartureCity { get; set; }
        [Required, MaxLength(100)]
        public string ArrivalCity { get; set; }
        //Relationship type
        //RelationshipType : One to many (1.....*)
        public Airplane Airplane { get; set; }//null
        //ForeignKey naming : RelatedEntityName + RelatedEntityPrimaryKeyName
        public int AirplaneId { get; set; }
        public ICollection<Client> Clients { get; set; }

    }
    public class AirplaneDbContext : DbContext  
    {
        //Collections
        //Clients
        //Airplanes
        //Flights
        public AirplaneDbContext()
        {
            //this.Database.EnsureDeleted();
            //this.Database.EnsureCreated();
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Flight> Flights { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-3HG9UVT\SQLEXPRESS;
                                            Initial Catalog = SuperAirplaneDb;
                                            Integrated Security=True;Connect Timeout=30;
                                            Encrypt=False;TrustServerCertificate=False;
                                            ApplicationIntent=ReadWrite;
                                            MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Initialization
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
