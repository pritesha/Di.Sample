using System;
using System.Collections.Generic;
using System.Text;

namespace Di.Sample.Services
{
    public class GreetingsService : IGreetingsService
    {
        public void SendCard()
        {
            Console.WriteLine("The card says Happy Birthday !!!");
        }
    }
}
