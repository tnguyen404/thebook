using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBook.ViewModels
{
    public class Stop
    {
        /// <summary>
        /// the city name where stop located
        /// </summary>
        [Required(ErrorMessage ="Tên trạm không được rỗng")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Vĩ độ không được rỗng")]
        public double Latitude { get; set; }
        [Required(ErrorMessage = "Kinh độ không được rỗng")]
        public double Longitude { get; set; }        
        public string Note { get; set; }
        public DateTime ArrivalDate { get; set; }
        public bool IsClosed { get; set; }
        public int Order { get; set; }
    }
}
