using AppInventario.Core.Interfaces;
using AppInventario.Core.Services;
using AppInventario.InfraStructure.Data;
using AppInventario.InfraStructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace AppInventario.Api
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
          //*  services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //funcion para no validar el modelo con el api controler
            services.AddControllers(options =>
            {
               //* options.Filters.Add<GlobalExceptionFilter>();
            })
                .AddNewtonsoftJson(option =>
                {
                    option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                })
            .ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddDbContext<INVENTARIOContext>(option => option.UseSqlServer(Configuration.GetConnectionString("INVENTARIO")));

            services.AddTransient<IClienteService, ClientesService>();

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("V1",new OpenApiInfo { Title="Proyecto Inventario", Version= "V1"});
                var xmlFile = $"{ Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory,xmlFile);
                doc.IncludeXmlComments(xmlPath);

            });

            services.AddAuthentication(options=> {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options=> {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateLifetime=true,
                    ValidateIssuerSigningKey=true,
                    ValidIssuer=Configuration["Authentication:Issuer"],
                    ValidAudience = Configuration["Authentication:Audience"],
                    
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:SecretKey"]))

                };
            });
            
            services.AddMvc();
            //services.AddMvc(options =>
            //{ //validacion global de los modelos q se ejecuten
            //    options.Filters.Add<ValidationFilter>();
            //}).AddFluentValidation(options =>
            //{//validator registros
            //    options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            //});


        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/swagger/V1/swagger.json","Proyecto Inventario");
            });
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
