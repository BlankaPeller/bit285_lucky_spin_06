using System;
using System.Linq;
namespace LuckySpin.Models
{
    public class Spin
    {
        public Player Player { get; set; }

        public long SpinId { get; set; }

        public bool IsWInning { get; set; }
    }

}
