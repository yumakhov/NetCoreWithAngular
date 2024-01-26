using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace NetCoreWithAngular.IntegrationTests
{
    public class TestWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            //base.ConfigureWebHost(builder);

            //builder.ConfigureServices(services =>
            //{
                
            //});

            builder.UseEnvironment("Development");
        }
    }
}
