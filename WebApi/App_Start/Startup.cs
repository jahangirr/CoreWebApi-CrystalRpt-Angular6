using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data;


namespace WebApi
{
    public class Startup
    {
        public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public  Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddCors(options =>
            {
                options.AddPolicy(name: "myCorsPolicy", policy =>
                  {
                      policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                  });
            });
            services.AddSwaggerGen();
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]);
            });
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [System.Obsolete]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env , DataContext db )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            // global cors policy
            app.UseCors("myCorsPolicy");
            app.UseAuthentication();
            
            app.UseRouting();
            app.UseAuthorization();
            db.Database.EnsureCreated();
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllers();
            });
           
           
            

           
        }
    }
}