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
        public string WebsiteLink { get; set; }
        public string ParkMapLink { get; set; }
        public List<Rating> Ratings { get; set; } // 1 Park => Many Ratings
        public List<Ride> Rides { get; set; } // 1 Park => Many Rides
        public List<Visit> Visits { get; set; } // 1 Park -> Many Visits

    }
}
