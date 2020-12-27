using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyThrillRideTrackerWebApp.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public List<ImageFileName> ImageFiles { get; set; }
    }
}
