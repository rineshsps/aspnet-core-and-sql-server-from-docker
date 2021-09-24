using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace UserAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // CreateHostBuilder(args).Build().Run();

            var host = CreateHostBuilder(args).Build();

            //{
            //    try
            //    {
            //        //database migration


            Console.Write($"Database Migrations start-v1!");
            using var scope = host.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<UserContext>();
            db.Database.Migrate();
            Console.Write($"Database Migrations completed!");
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.Write($"Database Migrations failed! {ex.Message.ToString()}");
            //        Environment.Exit(1);
            //        throw;
            //    }
            //}


            //{
            host.Run();
            //}
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
