using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _06_IntroToEntityFramework.Entities
{
    public class Airplane
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int MaxPassangers { get; set; }

        public ICollection<Flight> Flights { get; set; }
    }
}
