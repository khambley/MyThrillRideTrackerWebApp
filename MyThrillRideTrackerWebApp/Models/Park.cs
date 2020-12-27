using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyThrillRideTrackerWebApp.Models
{
    public class Park : BaseModel
    {
        public string City { get; set; }
        public string State { get; set; }
        public List<Rating> Ratings { get; set; } // 1 Park => Many Ratings
        public List<Ride> Rides { get; set; } // 1 Park => Many Rides

    }
}
