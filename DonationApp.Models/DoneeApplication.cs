using DonationApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Models
{
   public class DoneeApplication
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string  FullName { get; set; }
        public string UserId { get; set; }
        public string DOB { get; set; }
        public string PhoneNumber{ get; set; }
        public string HomeAddress { get; set; }
        public string Country { get; set; }
        public string EduLevel{ get; set; }
        public string Gender { get; set; }
        public string ItemNeeded { get; set; }
       public string ReasonForApplication { get; set; }
        public string ImageLink { get; set; }
        public string LetterOfRecLink { get; set; }
        public string NationalIdLink { get; set; }
        public  string OrgName  { get; set; }
        public string OrgWebsite { get; set; }
        public string OrgContact { get; set; }
        public string Signature{ get; set; }
        public string ApplicationStatus { get; set; }


        //Navigational Properties

        public AppUser users { get; set;}

        
    }
}
