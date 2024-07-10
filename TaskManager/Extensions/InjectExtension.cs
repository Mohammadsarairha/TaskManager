using Repository.Interfaces;
using Repository.Repositories;
using Services.Interfaces;
using Services.Services;

namespace TaskManager.Extensions
{
    public static class InjectExtension
    {
        public static WebApplicationBuilder AddInjection(this WebApplicationBuilder builder) 
        {
            builder.Services.AddScoped<IAuthRepository, AuthRepository>();
            builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
            builder.Services.AddScoped<IProjectTaskRepository, ProjectTaskRepository>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IProjectService, ProjectService>();
            builder.Services.AddScoped<IProjectTaskService, ProjectTaskService>();

            return builder;
        }
    }
}
