using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using DomainModels.Entities;
using Infrastructure.Data;
using Infrastructure.Logging;
using LeasingAPI.Common;
using LeasingAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
//using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
//using Swashbuckle.Swagger;
//using Swashbuckle.AspNetCore.SwaggerUI;
using Swashbuckle.AspNetCore.Swagger;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
//using Swashbuckle.Swagger;

namespace LeasingAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            #region Add DbContext

            services.AddDbContext<IranianLeasingContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("LeasingConnection")));

            services.AddControllers();

            #endregion

            #region Add MemoryCache

            services.AddMemoryCache();

            #endregion

            #region permission for wwwroot
            //services.AddSingleton<IFileProvider>(
            //    new PhysicalFileProvider(
            //        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));
            #endregion

            #region Add Cors To Services

            services.AddCors(o => o.AddPolicy("APIPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            #endregion

            #region Add Swagger To Services

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "سرویس های لیزینگ ایرانیان",
                    Description = "سرویس های مورد نیاز برای سامانه لیزینگ",
                    Contact = new OpenApiContact
                    {
                        Name = "Iraninan Leasing",
                        Email = "derambakht@gmail.com",
                        Url = new Uri("https://www.icleasing.ir/")
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            #endregion

            #region Read key from AppSettting & Add to Services.AppSettings

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSetting");
            services.Configure<AppSetting>(appSettingsSection);
            GlobalStaticData.PageItemCount = appSettingsSection.GetValue<int>("PageItemCount");

            #endregion

            #region Configure JWT Authentication

            var appSettings = appSettingsSection.Get<AppSetting>();
            var key = Encoding.UTF8.GetBytes(appSettings.Secret);
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

            #endregion

            #region Add Register DI Serices

            // configure DI for application services
            services.AddScoped(typeof(IAsyncRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddScoped(typeof(IUserService), typeof(UserService));

            #endregion

            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc().AddNewtonsoftJson();
            services.AddMvcCore().AddApiExplorer().ConfigureApiBehaviorOptions(o => { o.SuppressMapClientErrors = true; });

            services.AddRazorPages();

            #region DapperConnectionString

            services.AddTransient<IDbConnection>((sp) =>
                new SqlConnection(Configuration.GetConnectionString("LeasingConnection"))
        );

            #endregion

            #region Auto Mapper Configurations

            //var mappingConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new MappingProfile());
            //});

            //IMapper mapper = mappingConfig.CreateMapper();
            //services.AddSingleton(mapper);

            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            loggerFactory.AddFile("Logs/api-{Date}.txt");

            //HashSet<int> test = new HashSet<int>();
            //test.Add(1);
            //test.Add(1);
            //test.Add(1);
            //test.Add(1);
            //test.Add(1);

            //app.UseMiddleware<ErrorHandlerMiddleware>();


            #region register Swagger

            //// Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            //// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            //// specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Leasing API");
            });

            #endregion

            app.UseStaticFiles();
            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("APIPolicy");

            app.UseAuthentication();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}");
            //});

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
                endpoints.MapControllers();
            });
        }

        private void ConfigureInMemoryDatabases(IServiceCollection services)
        {
            // use in-memory database
            services.AddDbContext<IranianLeasingContext>(c =>
                c.UseInMemoryDatabase("Leasing"));

            ConfigureServices(services);
        }

        public void ConfigureProductionServices(IServiceCollection services)
        {
            services.AddDbContext<IranianLeasingContext>(c =>
                c.UseSqlServer(Configuration.GetConnectionString("LeasingConnection")));

            ConfigureServices(services);
        }
    }
}