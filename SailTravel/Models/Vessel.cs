using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoatJourney.Models
{
    public class Vessel
    {
        public int Id { get; set; }

        public string TypeOfVessel { get; set; }

        public string NameOfVessel { get; set; }

        public int PassangerCapacity { get; set; }

        [ForeignKey("TravelId")]
        public Travel Travel { get; set; }

        public int? TravelId { get; set; }
    }
}