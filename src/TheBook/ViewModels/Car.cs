using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBook.ViewModels
{
    public class Car
    {
       
        [Required(ErrorMessage ="Biển số xe không được rỗng")]
        public string CarNumber { get; set; }
        /// <summary>
        /// The capability number of people which can contain on this car
        /// </summary>
        [Required(ErrorMessage ="Số chỗ trên xe không được rỗng")]
        [Range(2,15,ErrorMessage ="Số chỗ phải từ 2 đến 15 chỗ")]
        public int SeatNumber { get; set; }
        [Required(ErrorMessage ="Tên xe không được trống")]
        public string CarName { get; set; }
        public string Note { get; set; }

        public bool IsAvailable { get; set; } = true;
    }
}
