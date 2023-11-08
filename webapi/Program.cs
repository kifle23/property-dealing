using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
using webapi.Data;
using webapi.Extentions;
using webapi.Helpers;
using webapi.Interfaces;
using webapi.Middlewares;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
//builder.Services.AddDbContext<DBContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

string dbPassword = Environment.GetEnvironmentVariable("DBPassword")!;

var conBuilder = new NpgsqlConnectionStringBuilder(builder.Configuration.GetConnectionString("DefaultConnection"))
{
    Password = dbPassword
};
var connectionString = conBuilder.ConnectionString;

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<DBContext>(opt =>
        opt.UseNpgsql(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(typeof(AutomapperProfiles).Assembly);

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularOrigins",
    builder =>
    {
        builder.WithOrigins(
                            "https://housing-app-ang.web.app"
                            )
                            .AllowAnyHeader()
                            .AllowAnyMethod();
    });
});

var secretKey = builder.Configuration.GetSection("AppSettings:Token").Value;
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key,
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

var app = builder.Build();

app.ConfigureExceptionHandler(app.Environment);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngularOrigins");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
