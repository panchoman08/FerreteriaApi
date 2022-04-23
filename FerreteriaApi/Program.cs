using FerreteriaApi;
using FerreteriaApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);


var app = builder.Build();
startup.Configure(app, app.Environment);
// Add services to the container.

/*builder.Services.AddControllers();
builder.Services.AddDbContext<ferreteria_dbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("FerreteriaDB"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddResponseCaching();*/
//var app = builder.Build();


// Configure the HTTP request pipeline.

app.Run();
