using Di.Sample.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Di.Sample
{
    public class SimpleApplication
    {
        private readonly IGreetingsService greetingsService;
        private readonly IThankingService thankingService;

        public SimpleApplication(IGreetingsService greetingsService, IThankingService thankingService)
        {
            this.greetingsService = greetingsService;
            this.thankingService = thankingService;
        }

        public void Run()
        {
            Console.WriteLine("Starting the simple application ......");
            greetingsService.SendCard();
            thankingService.SaysThanks();
            Console.WriteLine("Ending the simple application ......");
        }
    }
}
