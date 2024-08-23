using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
// using Azure.Identity;
// using Azure.Security.KeyVault.Secrets;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:4200", //dev local
                                "https://localhost:4200", //dev local
                                "http://192.168.50.173:4200", //dev external dotnet run --urls http://0.0.0.0:7254 
                                "https://192.168.50.173:4200", //dev external dotnet run --urls http://0.0.0.0:7254 
                                "https://localhost:4201", //staging docker
                                "http://localhost:4201", //staging docker
                                "https://orange-desert-0bb93bb0f.5.azurestaticapps.net", //prod azure api
                                "https://portfolio-webapi-hkh9cjbkepbha3gu.eastus-01.azurewebsites.net") //prod azure frontend
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});


var Configuration = builder.Configuration;

// Console.WriteLine(Configuration.GetSection("ConnectionStrings").GetSection("portfolioDB"));

var isDevelopment = builder.Environment.IsDevelopment();
if (isDevelopment)
{
    builder.Services.AddDbContext<TodoContext>(options =>
        options.UseNpgsql(Configuration.GetConnectionString("portfolioDBDev")));
}
else
{
    builder.Services.AddDbContext<TodoContext>(options =>
        options.UseNpgsql(Configuration.GetConnectionString("portfolioDB")));
}

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAuthorization();
builder.Services.AddAuthentication();

builder.Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<TodoContext>();


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapIdentityApi<User>();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
