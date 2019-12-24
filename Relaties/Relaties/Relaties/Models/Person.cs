using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Relaties.Models
{
    [Table("Person")]
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NamePerson { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [ForeignKey("IdAddress")]
        public Address AddressId { get; set; }
        public int? IdAddress{ get; set; }
    }
}