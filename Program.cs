using TodoApi.Services;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

// https://medium.com/@saisiva249/how-to-configure-postgres-database-for-a-net-a2ee38f29372

var builder = WebApplication.CreateBuilder(args);
// var connectionString = builder.Configuration.GetConnectionString("TodoDB") ?? "Data Source=Todo.db";

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

builder.Services.AddDbContext<TodoContext>(options =>
        options.UseNpgsql(Configuration.GetConnectionString("portfolioDB")));

// builder.Services.AddSqlServer<TodoContext>(connectionString);

// Add services to the container.
builder.Services.AddControllers();

// builder.Services.AddDbContext<TodoContext>(opt =>
//     opt.UseInMemoryDatabase("TodoItem"));

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
// .AddCookie(IdentityConstants.ApplicationScheme)
// .AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<TodoContext>();
// .AddApiEndpoints();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
// app.ApplyMigrations();
// }

// app.UseHttpsRedirection();

app.MapIdentityApi<User>();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

// app.MapIdentityApi<User>();

app.Run();
