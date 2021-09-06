using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Models
{
   public class NGO
    {
        public string Id { get; set; }
        public string LogoImageLink { get; set; }
        public string NGOName { get; set; }
        public string WebsiteLink { get; set; }

        //Navigational Properties
       public Appuser users { get; set; }

    }
}
