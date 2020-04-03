using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Di.Sample.Services
{
    public class GreetingsService : IGreetingsService
    {
        public void SendCard()
        {
            Log.Information("The logger is working fine !!!");
            Console.WriteLine("The card says Happy Birthday !!!");
        }
    }
}
