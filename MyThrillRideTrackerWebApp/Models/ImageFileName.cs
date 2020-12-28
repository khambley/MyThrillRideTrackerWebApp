using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyThrillRideTrackerWebApp.Models
{
    public class ImageFileName : BaseModel
    {
        public string FileName { get; set; }

        public virtual Visit Visit { get; set; } // 1 visit -> 1 Image (FK)

        public virtual Ride Ride { get; set; } // 1 ride -> 1 Image (FK)
        [NotMapped] 
        public int ParkId { get; set; }
        public virtual Park Park { get; set; } // 1 Park -> 1 Image (FK)
        public virtual Rating Rating { get; set; } // 1 Rating -> Image (FK)

    }
}
