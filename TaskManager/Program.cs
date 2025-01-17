using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Migrations.DataContext;
using Repository.Interfaces;
using Services.Interfaces;
using Services.Services;
using System.Text;
using Repository.Repositories;
using TaskManager.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TaskManagerDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
// Add Swagger
builder.UseSwagger();
// Inject Services
builder.AddInjection();
// Add Token
builder.AddAuthenticationToken();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder => builder
            .WithOrigins("https://localhost:4200") // Your Angular app's origin
            .AllowAnyHeader()
            .AllowAnyMethod()); // Allow credentials if you're sending cookies or other credentials
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAngularApp");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();


