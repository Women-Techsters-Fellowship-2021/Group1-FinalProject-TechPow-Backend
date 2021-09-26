using DonationApp.Models;
using System;
using System.Linq;
using System.Text;

namespace DonationApp.BuisnessLogic.Interfaces
{
    public interface IOTPGenerator
    {
        int RandomNumberGenerator(int min, int max);
    }
}