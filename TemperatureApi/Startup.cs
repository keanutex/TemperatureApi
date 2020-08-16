using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TemperatureApi.Helpers;
using TemperatureApi.Services;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using Microsoft.OpenApi.Interfaces;
using System;
using Microsoft.OpenApi.Any;

namespace TemperatureApi
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
            services.AddCors();
           
            services.AddControllers();

            services.AddTransient<UserService>();

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddScoped<UserService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Temperature API", Version = "v1", Description = "ASP.NET Core API for weather", });


                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {

                    Type = SecuritySchemeType.OAuth2,

                    Flows = new OpenApiOAuthFlows
                    {
                        Password = new OpenApiOAuthFlow
                        {
                            TokenUrl = new Uri("api/Users/authenticate", UriKind.Relative),
                            Extensions = new Dictionary<string, IOpenApiExtension>
                                {
                                    { "returnSecureToken", new OpenApiBoolean(true) },
                                },

                        }

                    }
                });
                //c.OperationFilter<AuthorizeCheckOperationFilter>();

                /*var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                   var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                   c.IncludeXmlComments(xmlPath);*/
                //});
            });

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = "";
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
