using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheBook.models
{
    public class TeamMember
    {
        public int Id { get; set; }
        /// <summary>
        /// Identity number of this employee
        /// </summary>
        [Required]
        public string IdentityCardNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string MobileNumber { get; set; }
        public string AnotherContact { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Note { get; set; }
        public RoleMember role { get; set; }
    }
}
