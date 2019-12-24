using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RelationsEF.Models
{
    public class Adres
    {
        public int Id { get; set; }
        public int Nummer { get; set; }
        public string Straat { get; set; }
        public string Bus { get; set; }

        public Adres() { }
    }
}