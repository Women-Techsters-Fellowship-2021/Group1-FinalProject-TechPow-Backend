using DonationApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Models
{
    public class Item
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public ItemCategory ItemCategory { get; set; }
        public ItemStatus ItemStatus { get; set; }
        public string DonatedBy { get; set; }
       public string DonatedTo { get; set; }
    }
}
