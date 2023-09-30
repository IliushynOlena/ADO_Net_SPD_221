using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _06_IntroToEntityFramework.Entities
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
        public DateTime? Birthdate { get; set; }//not null- ? null
        //---------------Navigation properties-----------------
       //Relationship type
        public ICollection<Flight> Flights { get; set; }

    }
}
