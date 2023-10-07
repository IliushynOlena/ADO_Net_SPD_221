using _06_IntroToEntityFramework.Entities;
using _06_IntroToEntityFramework.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace _06_IntroToEntityFramework
{
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)//Seeder
        {
            base.OnModelCreating(modelBuilder);
            //Initialization
            modelBuilder.SeedAirplane();
            modelBuilder.SeedFlights();

            //Fluent API configurations
            modelBuilder.Entity<Airplane>()
                .Property(a => a.Model)
                .HasMaxLength(100)
                .IsRequired();


            modelBuilder.Entity<Client>().ToTable("Passangers");
            modelBuilder.Entity<Client>().Property(C => C.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("FirstName");

            modelBuilder.Entity<Client>().Property(C => C.Email)
               .IsRequired()
               .HasMaxLength(100);


            modelBuilder.Entity<Flight>().HasKey(f=>f.Number);
            modelBuilder.Entity<Flight>().Property(f => f.DepartureCity)
               .IsRequired()
               .HasMaxLength(100);
            modelBuilder.Entity<Flight>().Property(f => f.ArrivalCity)
             .IsRequired()
             .HasMaxLength(100);

            //---------------Navigation properties-----------------
            modelBuilder.Entity<Flight>().HasMany(f => f.Clients).WithMany(c => c.Flights);
            modelBuilder.Entity<Flight>()
                .HasOne(f => f.Airplane)
                .WithMany(a => a.Flights)
                .HasForeignKey(f => f.AirplaneId);


        }

    }
}
