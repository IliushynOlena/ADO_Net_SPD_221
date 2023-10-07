using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _06_IntroToEntityFramework.Entities
{
    public class Flight
    {
       
        public int Number { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public int? Rating { get; set; }   
              
        public Airplane Airplane { get; set; }
     
        public int AirplaneId { get; set; }

        public ICollection<Client> Clients { get; set; }

    }
}
