using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Data;
using Presentation.Models;
using Presentation.Services;
using Data.Domain.Interfaces;
using Bussiness;
using Data.Domain.Entities;
using Data.Persistance;

namespace Presentation
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

            services.AddTransient<IDatabaseContext, DatabaseContext>();
            services.AddTransient<ITicketRepository, TicketRepository>();
            services.AddTransient<IStationRepository, StationRepository>();
//            services.AddTransient<IRouteNodeRepository, RouteNodeRepository>();
            services.AddTransient<ITrainRepository, TrainRepository>();
            services.AddTransient<IRouteRepository, RouteRepository>();
//            services.AddTransient(typeof(IDatabaseContextGeneric<>), typeof(DatabaseContextGeneric<>));
            services.AddTransient(typeof(IRepository<>), typeof(GenericRepository<>));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            var connectionString = @"Server=.\SQLEXPRESS;Database=Trains.Development;Trusted_Connection=true;";
            services.AddDbContext<DatabaseContext>(option => option.UseSqlServer(connectionString));
            services.AddMvc();

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
