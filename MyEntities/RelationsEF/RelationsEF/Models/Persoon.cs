using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RelationsEF.Models
{
    [Table("Persoon")]
    public class Persoon
    {
        [Key]
        public int Id { get; set; }
        public string Naam { get; set; }
        public DateTime GeboorteDatum { get; set; }

        [ForeignKey("AdresId")]
        public Adres Adres { get; set; }
        public int? AdresId { get; set; }

       
    }
}