using Autofac;
using Autofac.Extensions.DependencyInjection;
using Demo.Demo;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

var MyAllowSpecificOrigins = "AllowAllOrigins";
const string connectionStringName = "DefaultConnection";
var builder = WebApplication.CreateBuilder(args);
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", false, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables()
    .Build();
var webHostEnvironment = builder.Environment;
var connectionString = builder.Configuration.GetConnectionString(connectionStringName);
var migrationAssemblyName = typeof(Program).Assembly.FullName;

builder.Host.UseSerilog((ctx, lc) => lc
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(builder.Configuration));

builder.WebHost.UseUrls("http://*:80");

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder
        .RegisterModule(new DemoModule(connectionString, migrationAssemblyName));
});

builder.Services.AddDbContext<DemoContext>(o =>
{
    o.UseSqlServer(connectionString);

});



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder
            .WithOrigins(new[] { "http://localhost:4200/" })
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
}); ;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
