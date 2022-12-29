using Recognition.Infrastructure;
using Recognition.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using Hangfire;
using MediatR;
using System.Reflection;
using Recognition.Presistance.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructureServices(builder.Configuration);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), @"Files")))
{
    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), @"Files"));
}
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Files")),
    RequestPath = new PathString("/Files")
});

app.UseRouting();

app.UseAuthorization();
//app.UseHangfireDashboard("/hangfire/index");

app.MapControllers();
app.Run();
