using Data;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ServicesConfig
    {
        public static void ApplyMigrations(this IApplicationBuilder builder)
        {
            var services = builder.ApplicationServices.CreateScope();

            var context = services.ServiceProvider.GetService<LibraryContext>();

            context?.Database.Migrate();
        }
    }
}