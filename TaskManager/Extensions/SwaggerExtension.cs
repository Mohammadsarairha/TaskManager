using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace TaskManager.Extensions
{
    public static class SwaggerExtension
    {
        public static WebApplicationBuilder UseSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Task Manager API", Version = "v1" });
                options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            },
                            Scheme = "Oauth2",
                            Name = JwtBearerDefaults.AuthenticationScheme,
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });
            return builder;
        }
    }
}
