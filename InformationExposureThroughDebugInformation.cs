using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace mvcApp
{
    public class Startup2
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Those calls are Sensitive because it seems that they will run in production
            app.UseDeveloperExceptionPage(); // Sensitive
            app.UseDatabaseErrorPage(); // Sensitive
        }
    }
}
