using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using VoxConnections.Data.Context;

namespace Authetication.Context
{
    public class LTMContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        /// <summary>
        /// Classe onde estanciará o contexto existente, utilizada para fazer o Code First
        /// </summary>
        /// <param name="args"></param>
        /// <returns>Retona o contexto</returns>
        public DataContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var builder = new DbContextOptionsBuilder<DataContext>();

            var connectionString = configuration.GetConnectionString("LTMConnection");

            builder.UseSqlServer(connectionString);

            return new DataContext(builder.Options);
        }

    }
}
