using ITHelpdesk.Application.Hubs;
using ITHelpdesk.Application.Interfaces;
using ITHelpdesk.Application.Service;
using ITHelpdesk.Infrastructure.Context;
using ITHelpdesk.Infrastructure.Repositories.Implement;
using ITHelpdesk.Infrastructure.Repositories.Interface;
using ITHelpdesk.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//connect to database
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

// Register services
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IGithubService, GithubService>();
builder.Services.AddTransient<IGoogleService, GoogleService>();
builder.Services.AddTransient<IOllamaService, OllamaService>();


builder.Services.AddHttpClient("GitHubClient", client =>
{
    client.BaseAddress = new Uri("https://api.github.com/");
    client.DefaultRequestHeaders.UserAgent.ParseAdd("ITHelpdesk/1.0");
});

builder.Services.AddHttpClient("OllamaClient", client =>
{
    client.BaseAddress = new Uri("http://localhost:11434");
});

builder.Services.AddSignalR();

builder.Services.AddHttpClient();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .SetIsOriginAllowed(origin => true) 
            .WithExposedHeaders("Content-Disposition"); 
    });
});

var app = builder.Build();

app.UseCors("AllowSpecificOrigins");

app.MapHub<ChatHub>("/chathub");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
