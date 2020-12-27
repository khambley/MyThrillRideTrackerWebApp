using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyThrillRideTrackerWebApp.Models
{
    public class Rating
    {
        public int RatingId { get; set; }
        public decimal Stars { get; set; }
        public Park Park { get; set; }


    }
}
