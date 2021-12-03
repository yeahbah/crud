using CrudDemo.App;
using CrudDemo.Web.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder(args);
var cors = "allowcors";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: cors,
        builder =>
        {
            builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
        });
});

builder.Services.AddControllers();
builder.Services.AddLogging();
builder.Services.AddTransient<ExceptionHandlingMiddleware>();
builder.Services.AddAppServices(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseRouting();
app.UseCors(cors);

app.UseAuthorization();

app.MapControllers();

app.Run();
