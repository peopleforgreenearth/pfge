using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PFGE.Models
{
    [Bind(Exclude = "PlaceId")]
    public class Place
    {
        [Key]
        public int PlaceId { get; set; }
        [Required]
        public string Heading { get; set; }
        [Required]
        public string City { get; set; }
        public string Address { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
    }
}