using DonationApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Models
{
   public class Donor
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public ItemCategory ItemCategory{ get; set; }
        public string Model { get; set; }

        //Navigation properties
        public AppUser user { get; set; }
    }
}
