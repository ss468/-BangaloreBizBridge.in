using InvestHub.Core.Common;
using InvestHub.Core.Entities;
using InvestHub.Core.Interfaces.Repository;
using InvestHub.Core.Interfaces.Service;
using InvestHub.DAL.Repositories;
using InvestHub.Service.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

// MongoDB configuration
var mongoDBConnection = builder.Configuration.GetSection("MongoDB").Get<MongoDBConnectionOption>();

// Register DBConnectRepository
builder.Services.AddSingleton<IDBConnectionFactory>(_ => new DBConnectionFactory(mongoDBConnection?.connectionString, mongoDBConnection?.databaseName));

// Register IUserRepository
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPitchRepository, PitchRepository>();

// Register IUserService
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPitchService, PitchService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSingleton<IMongoCollection<UserEntity>>(provider =>
{
    var client = new MongoClient(mongoDBConnection?.connectionString);
    var database = client.GetDatabase(mongoDBConnection?.databaseName);
    return database.GetCollection<UserEntity>("User");
});builder.Services.AddSingleton<IMongoCollection<PitchEntity>>(provider =>
{
    var client = new MongoClient(mongoDBConnection?.connectionString);
    var database = client.GetDatabase(mongoDBConnection?.databaseName);
    return database.GetCollection<PitchEntity>("Pitch");
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
