using Microsoft.AspNetCore.Hosting;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Business.DependencyReselvers.Autofac;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                //autofact configurasyonu yapýldý. .Net default configurasyonunu kullanmamasý için biz tanýmlýyoruz.
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                //tanýmladýðýmýz business module ü burada veriyoruz.
                .ConfigureContainer<ContainerBuilder>(builder =>
                    {
                        builder.RegisterModule(new AutofacBusinessModule());
                    })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
