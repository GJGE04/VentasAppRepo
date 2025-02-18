using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VentasApp.Infrastructure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<VentasDbContext>
    {
        public VentasDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<VentasDbContext>();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("VentasDbConnection");

            optionsBuilder.UseSqlServer(connectionString);

            return new VentasDbContext(optionsBuilder.Options);
        }
    }
}
