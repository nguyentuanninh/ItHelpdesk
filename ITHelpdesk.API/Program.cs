using ITHelpdesk.Application.Hubs;
using ITHelpdesk.Application.Interfaces;
using ITHelpdesk.Application.Service;
using ITHelpdesk.Application;
using ITHelpdesk.Infrastructure.Context;
using ITHelpdesk.Infrastructure.Repositories.Implement;
using ITHelpdesk.Infrastructure.Repositories.Interface;
using ITHelpdesk.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Connect to database
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

// Register services
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IAuthService, AuthService>();
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

var key = builder.Configuration.GetValue<string>("ApiSettings:Secret");
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false; 
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
        ValidateIssuer = false,
        ValidateAudience = false,
    };

    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var accessToken = context.Request.Query["access_token"];
            var path = context.HttpContext.Request.Path;
            if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/api/notificationHub"))
            {
                context.Token = accessToken;
            }
            return Task.CompletedTask;
        },
        OnTokenValidated = async context =>
        {
            var userIdClaim = context.Principal?.FindFirst("userId");
            if (userIdClaim == null)
            {
                context.Fail("Unauthorized");
                return;
            }

            if (!int.TryParse(userIdClaim.Value, out int userId))
            {
                context.Fail("Unauthorized");
                return;
            }

            // TODO: Check lai khi su dung SignalR
            // var dbContext = context.HttpContext.RequestServices.GetRequiredService<ApplicationDBContext>();
            // var user = (await dbContext.Employees.FindAsync(x => x.Id == userId));
            // if (user == null || user.)
            // {
            //     context.Fail("Unauthorized");
            // }
        }
    };
});

builder.Services.AddSignalR();
builder.Services.AddHttpClient();
builder.Services.AddAutoMapper(typeof(Mapping));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
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

app.UseCors("AllowAll");

app.MapHub<ChatHub>("/chathub");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
