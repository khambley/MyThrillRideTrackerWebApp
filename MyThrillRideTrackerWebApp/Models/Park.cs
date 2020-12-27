using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyThrillRideTrackerWebApp.Models
{
    public class Park
    {
        public int ParkId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public List<Rating> Ratings { get; set; }
        public List<Ride> Rides { get; set; }

    }
}
