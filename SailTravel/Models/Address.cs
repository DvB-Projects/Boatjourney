using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BoatJourney.Models
{
    [Table("Address")]
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string StreetName { get; set; }

        [Required]
        public int HouseNr { get; set; }

        [ForeignKey("ZipCodeId")]
        public Zipcode ZipCode { get; set; }

        public int? ZipCodeId { get; set; }
    }
}