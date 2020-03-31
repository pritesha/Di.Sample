using Di.Sample.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Di.Sample
{
    public class SimpleApplication
    {
        private readonly IGreetingsService greetingsService;

        public SimpleApplication(IGreetingsService greetingsService)
        {
            this.greetingsService = greetingsService;
        }

        public void Run()
        {
            Console.WriteLine("Starting the simple application ......");
            greetingsService.SendCard();
            Console.WriteLine("Ending the simple application ......");
        }
    }
}
