using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Convidados
{
    /// <summary>
    /// Classe Program
    /// </summary>
    public class Program
    {

        /// <summary>
        /// Método Main
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        /// <summary>
        /// BuildWebHost
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
