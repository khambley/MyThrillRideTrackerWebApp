using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyThrillRideTrackerWebApp.Models
{
    public class ImageFileName : BaseModel
    {
        public string FileName { get; set; }

        public Visit Visit { get; set; } // 1 visit -> 1 Image (FK)

        public Ride Ride { get; set; } // 1 ride -> 1 Image (FK)

        public Park Park { get; set; } // 1 Park -> 1 Image (FK)
        public Rating Rating { get; set; } // 1 Rating -> Image (FK)

    }
}
