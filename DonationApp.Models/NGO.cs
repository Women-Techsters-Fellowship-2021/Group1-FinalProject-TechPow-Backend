using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Models
{
   public class NGO
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string LogoImageLink { get; set; }
        public string NGOName { get; set; }
        public string WebsiteLink { get; set; }

        //Navigational Properties
       public AppUser users { get; set; }

    }
}
