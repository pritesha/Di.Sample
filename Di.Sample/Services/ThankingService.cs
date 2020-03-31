using System;
using System.Collections.Generic;
using System.Text;

namespace Di.Sample.Services
{
    public class ThankingService : IThankingService
    {
        public void SaysThanks()
        {
            Console.WriteLine("Thank you for the wonderful message !!");
        }
    }
}
