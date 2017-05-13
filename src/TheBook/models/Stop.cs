using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBook.models
{
    public class Stop
    {
        public int Id { get; set; }
        /// <summary>
        /// the city name where stop located
        /// </summary>
        [Required]
        public string Name { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string Note { get; set; }
        public string StopStatus { get; set; }
        public bool IsClosed { get; set; }
        public int Order { get; set; }

    }
}
