using Microsoft.AspNetCore.Hosting;
using System.Reflection;
using System;
using VetScheduler.Data.Context;
using Autofac.Core;
using MediatR;
using VetScheduler.Services.Mappings;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddDefaultPolicy(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddDbContext<VetSchedulerEFContext>(c =>
          c.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var assemblies = new Assembly[]
{
  typeof(Program).Assembly,
  typeof(VetSchedulerEFContext).Assembly
};

builder.Services.AddMediatR(assemblies);

builder.Services.AddAutoMapper(typeof(VetSchedulerMappings));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
