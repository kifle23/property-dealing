using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Helpers;
using webapi.Interfaces;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContext<DBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
                            "http://localhost:4200"
                            )
                            .AllowAnyHeader()
                            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("AllowAngularOrigins");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
