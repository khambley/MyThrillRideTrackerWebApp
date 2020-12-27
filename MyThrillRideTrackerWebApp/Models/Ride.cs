using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MyThrillRideTrackerWebApp.Models
{
    public class Ride
    {
        public int RideId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        public int TopSpeed { get; set; } //mph
        public DateTime Year { get; set; }
        public string ImageFileName { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public Park Park { get; set; }
        


    }
}
