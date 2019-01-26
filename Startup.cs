using System.Linq;
using hu.jia.ZippedWebAPI.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace hu.jia.ZippedWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhostOrigin",builder => builder.WithOrigins("http://localhost:63342").AllowCredentials().AllowAnyMethod().AllowAnyHeader().WithExposedHeaders("Content-Length"));
            });
            
            services.AddMvc(options => {
                options.Filters.Add(new AddHeaderAttribute("Author", "Ben me@jia.hu"));
            });

            services.AddResponseCompression(options =>
            {
                //options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();
                options.Providers.Add<LZ4CompressionProvider>();
                // The wildcard MIME types, such as text/* aren't supported
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "image/svg+xml", "application/json", "application/xml" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); 
                app.UseDatabaseErrorPage();
            }

            app.UseCors("AllowLocalhostOrigin");
            // app.UseResponseCompression must be called before app.UseMvc
            app.UseResponseCompression();
            app.UseMvc();
        }
    }
}
