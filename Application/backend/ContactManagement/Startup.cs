using CoffeeApplication.Interfaces;
using CoffeeApplication.Services;
using CoffeeApplication.Settings;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using System.Reflection.Metadata;
using System;
using System.Net;


using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Text.Json;

namespace CoffeeApplication
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

            services.AddControllers().AddJsonOptions(options => {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            services.Configure<CoffeeApplicationStoreDatabaseSetting>(Configuration.GetSection(nameof(CoffeeApplicationStoreDatabaseSetting)));

            services.AddSingleton<ICoffeeApplicationStoreDatabaseSetting>(sp => sp.GetRequiredService<IOptions<CoffeeApplicationStoreDatabaseSetting>>().Value);
            services.AddSingleton<IMongoClient>(S => new MongoClient(Configuration.GetValue<string>("CoffeeApplicationStoreDatabaseSetting:ConnectionString")));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPointsSettingsService, PointsSettingsService>();
            services.AddScoped<IProductService, ProductService>();


            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                );
            });

            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Coffee Application", Version = "v1.0" });
            }
            );

            


            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "FIR v1");
                    c.OAuthClientId("A_SwaggerClient");
                });
            }


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Define global error handler
                app.UseExceptionHandler(errorApp =>
                {
                    errorApp.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "application/json";

                        var exception = context.Features.Get<IExceptionHandlerFeature>();
                        if (exception != null)
                        {
                            var errorMessage = new
                            {
                                message = "Internal Server Error"
                            };
                            string errorJson = System.Text.Json.JsonSerializer.Serialize(errorMessage);
                            await context.Response.WriteAsync(errorJson);
                        }
                    });
                });


            }






                app.UseHttpsRedirection();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());


            app.UseHttpsRedirection();
            app.UseRouting();
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
