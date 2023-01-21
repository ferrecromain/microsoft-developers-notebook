using LoyaltyCardManager.Infrastructure.Data;
using LoyaltyCardManager.WebApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LoyaltyCardManager.Test.Fixtures
{
    public class WebApiTestFixture : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.BuildServiceProvider().GetService<ApplicationDbContext>()!.Database.Migrate();
            });
            base.ConfigureWebHost(builder);
        }
    }
}
