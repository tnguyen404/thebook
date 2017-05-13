using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheBook.ViewModels
{
    public class TeamMember
    {
        /// <summary>
        /// Identity number of this employee
        /// </summary>
        [Required(ErrorMessage ="Mã nhân viên không được rỗng")]
        public string IdentityCardNumber { get; set; }
        [Required(ErrorMessage = "Tên nhân viên không được rỗng")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Số điện thoại không được rỗng")]
        public string MobileNumber { get; set; }
        public string AnotherContact { get; set; }
        [Required(ErrorMessage = "E-mail không được rỗng")]
        [EmailAddress(ErrorMessage ="E-mail không hợp lệ")]
        public string Email { get; set; }
        public string Note { get; set; }
    }
}
