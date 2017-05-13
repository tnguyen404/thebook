using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBook.models
{
    public class RoleMember
    {
        public int Id { get; set; }
        [Required]
        public string RoleName { get; set; }

    }
}
