using AutoMapper;
using DClinic.Application.Services;
using DClinic.Domain.Data;
using DClinic.Domain.Entities;
using DClinic.Domain.Interfaces;
using DClinic.Domain.Mapper;
using DClinic.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

//TODO put this into another extention
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IGenericRepository<Patient>, GenericRepository<Patient>>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add ServiceCollection Mapper
builder.Services.AddAutoMapperConfiguration();

//add custom Json as config file
builder.Configuration.AddJsonFile("appsettings.json");
var configuration = builder.Configuration;

builder.Services.AddDbContext<DclinicContext>(opt =>
{
    opt.UseSqlServer(configuration.GetConnectionString("ConnectionStrings:DClinicConStr"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
