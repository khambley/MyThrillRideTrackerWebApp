using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyThrillRideTrackerWebApp.Models
{
    public class Rating : BaseModel
    {
        public decimal Stars { get; set; }

        // 1 Park -> 1 Rating (FK)
        public Park Park { get; set; }

        // 1 Ride -> 1 Rating (FK)
        public Ride Ride { get; set; }

    }
}
