using Microsoft.AspNetCore.Authentication.JwtBearer;
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
          
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
