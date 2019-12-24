using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoatJourney.Models
{
    public class Travel
    {
        [Key]
        public int Id { get; set; }

        public string TypeTravel { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BookingDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime EndDate { get; set; }

        public List<Vessel> VesselList { get; set; }

        [ForeignKey("TravelOrganiserId")]
        public TravelOrganiser TravelOrganiser { get; set; }

        public int? TravelOrganiserId { get; set; }


        public Travel()
        {
            VesselList = new List<Vessel>();
        }
    }
}