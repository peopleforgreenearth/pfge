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

        public string UserID { get; set; }
    }

    public class PlacePhoto
    {
        [Key]
        public int PlacePhotoId { get; set; }
        [Required]
        public int PlaceId { get; set; }
        [Required]
        public string PhotoName { get; set; }
        [Required]
        public string PhotoDescription { get; set; }
    }

    [Bind(Exclude = "EventId")]
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        [Required]
        public string EventName { get; set; }
        [Required]
        public DateTime EventDate { get; set; }
        [Required]
        public string EventDescription { get; set; }
    }

    [Bind(Exclude = "EventPhotoId")]
    public class EventPhoto
    {
        [Key]
        public int EventPhotoId { get; set; }
        [Required]
        public int EventId { get; set; }
        [Required]
        public string PhotoName { get; set; }
        [Required]
        public string PhotoDescription { get; set; }
    }


}