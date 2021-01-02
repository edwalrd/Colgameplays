using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Colgameplays.Context;
using Microsoft.EntityFrameworkCore;
using Colgameplays.Repositorio;
using Colgameplays.Contracto;
using AutoMapper;
using System.Text;
using System.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using Colgameplays.Options;
using Newtonsoft.Json;

namespace Colgameplays
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
            services.AddControllers();

            services.AddMvc(option => option.EnableEndpointRouting = false)
          .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
          .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<ColgamesplaysContenxt>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("DefaulConnectionString")));

            services.AddScoped<IArticuloRepositorio, ArticuloRepositorio>();

            services.AddScoped<IPlataformaRepositorio, PlataformaRepositorio>();

            services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();

            services.AddScoped<ICarritoRepositorio, CarritoRepositorio>();

            services.AddScoped<IConsolaRepositorio, ConsolaRepositorio>();

            services.AddScoped<IDomicilioRepositorio, DomicilioRepositorio>();

            services.AddScoped<IAuthRepositorio, AuthRepositorio>();

            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            services.AddScoped<IimagenRepositorio, ImagenRepositorio>();

            services.AddScoped<IOrdenesRepositorio, OrdenesRepositorio>();

            services.AddScoped<IPasswordRepositorio, PasswordRepositorio>();

            services.Configure<PasswordOptions>(Configuration.GetSection("PasswordOptions"));

            services.AddHttpContextAccessor();

            services.AddSwaggerGen(doc =>
            {

                doc.SwaggerDoc("v1", new OpenApiInfo { Title = "Colgameplays", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                doc.IncludeXmlComments(xmlPath);

            });


            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["JwtSettings:Issuer"],
                    ValidAudience = Configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSettings:SecretKey"]))
                };
            });

            services.AddCors(options =>
            {

                options.AddPolicy("CorsPolicy",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Colgameplays API V1");
                options.RoutePrefix = string.Empty;
            });

            app.UseAuthentication();
            app.UseAuthorization();
    

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
