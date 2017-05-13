using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBook.models
{
    public class Car
    {
        public int Id { get; set; }
        /// <summary>
        /// The identify number of this car
        /// </summary>
        [Required]
        public string CarNumber { get; set; }
        /// <summary>
        /// The capability number of people which can contain on this car
        /// </summary>
        [Required]
        public int SeatNumber { get; set; }
        [Required]
        public string CarName { get; set; }
        /// <summary>
        /// currently this car can use or not
        /// </summary>
        public bool IsAvailable { get; set; }
        /// <summary>
        /// assumption available date
        /// </summary>
        public DateTime AvailableUntil { get; set; }
        public string Note { get; set; }

    }
}
