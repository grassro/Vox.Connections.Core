using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Authetication.Data.Repository;
using Authetication.Data;
using VoxConnections.Data.Context;

namespace Authentication
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var serviceProvider = new ServiceCollection()
                .AddSingleton<IUsuarioRepository, UsuarioRepository>()
                //.AddSingleton<IProdutosRepository, ProdutosRepository>()
                .BuildServiceProvider();

                try
                {
                    var context = services.GetRequiredService<DataContext>();

                    //Caso a base esteja criada, comentar
                    //SeedData.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
