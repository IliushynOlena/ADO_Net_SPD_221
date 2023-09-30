using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _06_IntroToEntityFramework.Entities
{
    public class Flight
    {
        //properties
        //public int Id { get; set; }
        //Primary key naming : Id/id/ID/ EntityName+Id(FlightId)
        [Key]//Primary key
        public int Number { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        [Required, MaxLength(100)]
        public string DepartureCity { get; set; }
        [Required, MaxLength(100)]
        public string ArrivalCity { get; set; }

        public int? Rating { get; set; }//value -  null
        //Relationship type
        //RelationshipType : One to many (1.....*)
        //---------------Navigation properties-----------------
        public Airplane Airplane { get; set; }//null
        //ForeignKey naming : RelatedEntityName + RelatedEntityPrimaryKeyName
        public int AirplaneId { get; set; }
        //RelationshipType : Many to many (*.....*)
        public ICollection<Client> Clients { get; set; }

    }
}
