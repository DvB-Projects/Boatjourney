using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Relaties.Models
{
    [Table("Address")]
    public class Address
    {
        public int Id { get; set; }

        [Required]
        public string StreetName { get; set; }

        [Required]
        public int HouseNr { get; set; }

        [Required]
        public int BusNr { get; set; }
    }
}