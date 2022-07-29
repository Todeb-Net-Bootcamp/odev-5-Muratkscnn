using DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Configuration.Extensions
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var MbContext = scope.ServiceProvider.GetRequiredService<EmkaContext>())
                {
                    try
                    {
                        MbContext.Database.Migrate();

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            return host;
        }

    }
}
