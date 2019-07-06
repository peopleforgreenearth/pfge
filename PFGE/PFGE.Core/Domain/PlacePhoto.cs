using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PFGE.Core.Domain
{
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
}
