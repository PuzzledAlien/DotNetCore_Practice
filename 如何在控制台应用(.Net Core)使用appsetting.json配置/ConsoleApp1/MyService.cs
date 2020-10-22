using System;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp1
{
    class MyService : IMyService
    {
        private readonly IConfiguration _configuration;
        public MyService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SayMyWords()
        {
            var section = _configuration.GetSection("MyWords");
            Console.WriteLine(section.Value);
        }
    }
}
