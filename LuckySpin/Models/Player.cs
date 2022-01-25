using System.ComponentModel.DataAnnotations;
namespace LuckySpin.Models
{
    public class Player
    {
        public long PlayerId { get; set; }

        public string FirstName { get; set; }

        public int Luck { get; set; }

        public int StartingBalance { get; set; }
    }
}