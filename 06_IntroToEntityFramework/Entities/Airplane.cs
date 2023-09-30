using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _06_IntroToEntityFramework.Entities
{
    public class Airplane
    {
        //properties
        public int Id { get; set; }//not null
        [Required, MaxLength(100)]
        public string Model { get; set; }//null - not null
        public int MaxPassangers { get; set; }//not null
        //---------------Navigation properties-----------------
        //Relationship type
        public ICollection<Flight> Flights { get; set; }
    }
}
