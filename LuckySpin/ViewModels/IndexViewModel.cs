using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LuckySpin.ViewModels
{
    public class IndexViewModel
    {
        [Required (ErrorMessage = "*Please add your name")]
        public string FirstName { get; set; }

        [Range(1, 9, ErrorMessage = "Please select a valid number")]
        public int Luck { get; set; }

        [Range(3.0, 10.0, ErrorMessage = "Please input a valid amount of money between $3 and $10")]
        public decimal StartingBalance { get; set; }
    }
}
