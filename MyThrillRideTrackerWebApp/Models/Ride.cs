using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MyThrillRideTrackerWebApp.Models
{
    public class Ride : BaseModel
    {
        public int Height { get; set; }
        public int Length { get; set; }
        public int TopSpeed { get; set; } //mph
        public string RideType { get; set; }

        [DataType(DataType.Date)]
        public DateTime BuildDate { get; set; }

        public List<Rating> Ratings { get; set; } // 1 Ride -> Many Ratings

        public int ParkId { get; set; }
        public Park Park { get; set; } // 1 Park -> 1 Ride 
        
    }
}
