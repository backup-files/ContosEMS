using ContosEMS.Data;
using ContosEMS.Data.GraphQL;
using ContosEMS.Repositories;
using GraphQL;
using GraphQL.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationToo.Data.GraphQL;

namespace ContosEMS
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
            DbInterception.Add(new CreateDatabaseCollationInterceptor("Latin1_General_CS_AS"));

            services.AddControllers();
            services.AddDbContext<EMSDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:EMS"]);
            });
            
            services.AddScoped<EquipmentRepository>();
            services.AddScoped<NotificationRepository>();
            services.AddScoped<PlantAdminRepository>();
            services.AddScoped<TechnicianRepository>();

            services.AddScoped<IServiceProvider>(s =>
            {
                return new FuncServiceProvider(s.GetRequiredService);
            });
            services.AddScoped<EMSSchema>();
            services
                .AddGraphQL()
                .AddSystemTextJson()
                .AddGraphTypes(ServiceLifetime.Scoped);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, EMSDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseGraphQL<EMSSchema>();
            app.UseGraphQLPlayground();
            context.Seed();
            UserManager.AddUsers(context);
        }
    }
}
