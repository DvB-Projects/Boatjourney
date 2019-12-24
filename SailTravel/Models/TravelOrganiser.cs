using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoatJourney.Models
{
    public class TravelOrganiser
    {
        [Key]
        public int Id { get; set; }

        public string NameOrganiser { get; set; }

        public List<Travel> TravelList { get; set; }

        public TravelOrganiser()
        {
            TravelList = new List<Travel>();
        }
    }
}