using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBook.models
{
    public class Tracking
    {
        public int Id { get; set; }
        public Stop FromStop { get; set; }
        public Stop ToStop { get; set; }
        public double KilometerTotal { get; set; }
        public string  Note { get; set; }
        /// <summary>
        /// Chi phi phat sinh
        /// </summary>
        public double CostsIncurred { get; set; }
        public string TaskDescription { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
