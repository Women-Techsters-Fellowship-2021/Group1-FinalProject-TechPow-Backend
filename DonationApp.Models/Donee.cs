using DonationApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Models
{
   public class Donee
    {
        public string Id { get; set; }
        public DateTime DOB { get; set; }
        public string ItemNeeded { get; set; }
        public string ItemID { get; set; }
        public Gender Gender { get; set; }
        public CareerStatus CareerStatus { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public string ShortBio { get; set; }
        public string ImageLink { get; set; }

        //Navigational Properties

        public Appuser users { get; set;}
     
    }
}
