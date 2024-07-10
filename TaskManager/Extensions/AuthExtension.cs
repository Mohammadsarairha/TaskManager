using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Migrations.DataContext;
using System.Text;

namespace TaskManager.Extensions
{
    public static class AuthExtension
    {
        public static WebApplicationBuilder AddAuthenticationToken(this WebApplicationBuilder builder)
        {
            builder.Services.AddIdentityCore<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("TaskManager")
                .AddEntityFrameworkStores<TaskManagerDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });

            var jwtKey = builder.Configuration["Jwt:key"];
            if (string.IsNullOrEmpty(jwtKey))
            {
                throw new InvalidOperationException("JWT key is not configured.");
            }

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                };
            });

            return builder;
        }
    }
}
