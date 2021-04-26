using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Csoin.Server.Persistence.Tests;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Csoin.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //PersistenceTests t = new PersistenceTests();
            //t.TestMethod1();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
