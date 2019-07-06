using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PFGE.Core.Domain
{   
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

        public string UserID { get; set; }
    }
}
