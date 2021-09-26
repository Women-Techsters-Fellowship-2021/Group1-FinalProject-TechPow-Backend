using DonationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.BuisnessLogic.Implementations
{
    public class OTPGenerator
    {
        private readonly Random _random = new Random();
        public int RandomNumberGenerator(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}