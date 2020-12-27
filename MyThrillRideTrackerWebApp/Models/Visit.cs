using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MyThrillRideTrackerWebApp.Models
{
    public class Visit : BaseModel
    {
        
        public Park Park { get; set; } // 1 Park per 1 Visit, 1-1
        public List<Ride> Rides { get; set; } // 1 Visit -> Many Rides
        public DateTime VisitDate { get; set; }
        
        // 1 visit -> Many Images List of images


    }
}
