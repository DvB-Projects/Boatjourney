using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoatJourney.Models
{
    [Table("Zipcode")]
    public class Zipcode
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PostCode { get; set; }

        //public override string ToString()
        //{
        //    return $"{PostCode} {PlaceOfStay}";
        //}
    }
}