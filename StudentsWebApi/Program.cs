using DomainLayar.DataBase;
using DomainLayar.Model;
using Microsoft.EntityFrameworkCore;
using RepositoryLayar.IRepository;
using RepositoryLayar.Repository;
using ServiceLayer.CustomSerrvices;
using ServiceLayer.ICustomServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string ConnectionString = builder.Configuration.GetConnectionString("DataBaseConnectionString");
builder.Services.AddDbContext<GenericDB>(x=> x.UseSqlServer(ConnectionString));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICustomService<Student>, StudentService>();
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
