using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Music.Core;
using Music.Core.Repositorys;
using Music.Core.Services;
using Music.Data;
using Music.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IMusicService, MusicService>();
builder.Services.AddTransient<IArtistService, ArtistService>();

// Register DbContext
builder.Services.AddDbContext<MusicDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("connectionString"));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



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
