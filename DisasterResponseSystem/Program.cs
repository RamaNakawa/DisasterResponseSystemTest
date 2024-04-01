
using DisasterResponseSystem.Models;
using DisasterResponseSystem.Service;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, true);
builder.Services.AddControllers();
builder.Services.AddDbContext<DataBaseConext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DBContxt")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ILogicService, LogicService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                      });
});

var scope = builder.Services.BuildServiceProvider().CreateScope();
using var dbContext = scope.ServiceProvider.GetService<DataBaseConext>();
MigrateDB.MigrateDb(dbContext);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }