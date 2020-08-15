using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using TemperatureApi.Helpers;

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
            services.AddControllers();

            //services
            //.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Api", Version = "v1" });

            //    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            //    {

            //        Type = SecuritySchemeType.OAuth2,

            //        Flows = new OpenApiOAuthFlows
            //        {
            //            Password = new OpenApiOAuthFlow
            //            {
            //                TokenUrl = new Uri("/v1/auth", UriKind.Relative),
            //                Extensions = new Dictionary<string, IOpenApiExtension>
            //                    {
            //                        { "returnSecureToken", new OpenApiBoolean(true) },
            //                    },

            //            }

            //        }
            //    });
            //    c.OperationFilter<AuthorizeCheckOperationFilter>();
            //});

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.Authority = "https://securetoken.google.com/temperature-api-dd013"; 
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = "https://securetoken.google.com/temperature-api-dd013",
                    ValidateAudience = true,
                    ValidAudience = "temperature-api-dd013",
                    ValidateLifetime = true
                };
                options.RequireHttpsMetadata = false;
            });
          
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Temperature API", Version = "v1", Description = "ASP.NET Core API for weather", });

                /*var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);*/
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = "swagger";
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

          //  app.UseSwagger(c =>
          //  {
          //      c.SerializeAsV2 = true;
          //  });

          //  app.UseSwagger()
          //.UseSwaggerUI(c =>
          //{
          //    c.SwaggerEndpoint($"/swagger/v1/swagger.json", "Chivado Api");
          //      //c.RoutePrefix = string.Empty;
          //  });

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
  
        }
    }
}
