using CodiJobServices.Model;
using Domain.IRepositories;
using Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Infraestructure.Persistencia;
using Infraestructure.Repositories;
using Application.IServices;
using Application.Services;
using Application.DTOs;
using Infraestructure.Transversal.FluentValidations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infraestructure.Transversal.Authentication;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Infraestructure.Transversal.Swagger;

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

            //REPOSITORIES
            services.AddTransient<IProyectoRepository, EFProyectoRepository>(); //lo inyectamos por dependencia
            services.AddTransient<ISkillRepository, EFSkillsRepository>();
            services.AddTransient<IGrupoRepository, EFGrupoRepository>();
            services.AddTransient<IUsuarioPerfilRepository, EFUsuarioPerfilRepository>();

            //SERVICIOS
            services.AddTransient<IProyectoService, ProyectoService>();
            services.AddTransient<IUsuarioPerfilService, UsuarioPerfilService>();
            services.AddTransient<IGrupoService, GrupoService>();
            services.AddTransient<ISkillService, SkillService>();
            services.AddTransient<IUserService, UserService>();

            //VALIDATORS
            services.AddTransient<IValidator<ProyectoDTO>, ProyectoDTOValidator>();
            services.AddTransient<IValidator<SkillDTO>, SkillDTOValidator>();
            services.AddTransient<IValidator<GrupoDTO>, GrupoDTOValidator>();
            services.AddTransient<IValidator<UsuarioPerfilDTO>, UsuarioPerfilDTOValidator>();

            // configure jwt authentication
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


            services.AddSwaggerDocumentation();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info { Title = "CodiJobServices", Version = "v1" });
            });
            services.AddMvc().AddFluentValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerDocumentation();
            app.UseAuthentication(); //para usar autenticacion
            app.UseMvc();
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
