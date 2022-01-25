using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuckySpin.Models
{
    public class SpinViewModel
    {
        public int[] Numbers { get; set; }

        public string CurrentBalance { get; set; }

        public bool IsWinning { get; set; }

        public string PlayerName { get; set; }

        public int PlayerLuck { get; set; }
    }
}
