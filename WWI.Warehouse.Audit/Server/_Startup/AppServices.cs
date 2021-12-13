using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WWI.Warehouse.Audit.Server
{
    public static class AppServices
    {
        public static void AddAppServices(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment hostingEnv)
        {
        }
    }
}
