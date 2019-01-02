using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodiJobServices.Model;
using CodiJobServices.Model.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using WebApplication_CodiJob.Model.CodiJobDb;

namespace WebApplication_CodiJob
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
            // agregamos el servicio que usa sql server y le enviamos la cadena de conexion
            // le estasmos agregando una cadena de conexion
            services.AddDbContext<CodiJobDbContext>(options => options.UseSqlServer(Configuration["Data:CodiJob:ConnectionString"]));

            // le decimos al servicio su propia cadena de conexion
            // esto para que trabajen con diferentes bases de datos
            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(
                Configuration["Data:CodiJobIdentity:ConnectionString"]));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IProyectoRepository, EFProyectoRepository>(); //lo inyectamos por dependencia

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info { Title = "CodiJobServices", Version = "v1" });
            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseAuthentication(); //para usar autenticacion
            app.UseMvc();
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
