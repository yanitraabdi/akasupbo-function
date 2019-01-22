using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pusaka.DataService.Constants;
using Pusaka.DataService.Contexts;
using Pusaka.DataService.Interfaces;
using Pusaka.DataService.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pusaka.DataService.Modules
{
    public class AppCoreModule : AppModule
    {
        public override void Load(IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();

            var connectionString = config.GetConnectionString(ApplicationConfiguration.PusakaConnectionString);

            var optionsBuilder = new DbContextOptionsBuilder<PusakaContext>();
            optionsBuilder.UseSqlServer(connectionString);

            var context = new PusakaContext(optionsBuilder.Options);

            services.AddSingleton<ISchoolService, SchoolService>(s => new SchoolService(config, context));
        }
    }
}
