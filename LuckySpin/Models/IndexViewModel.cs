using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LuckySpin.Models
{
    public class IndexViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Range(1, 9)]
        public int Luck { get; set; }

        [Range(3.0, 10.0)]
        public decimal StartingBalance { get; set; }
    }
}
