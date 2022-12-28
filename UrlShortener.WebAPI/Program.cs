using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using UrlShortener.WebAPI.DAL;
using UrlShortener.WebAPI.Models;
using UrlShortener.WebAPI.Services;
using UrlShortener.WebAPI.Services.Abstract;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string dbConnectionString = builder.Configuration.GetConnectionString("UrlShortenerDb");
builder.Services.AddDbContext<UrlShortenerDbContext>(options => options.UseSqlServer(dbConnectionString)); 
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<UrlShortenerDbContext>();
builder.Services.AddTransient<IUrlShortenerService, UrlShortenerService>();
builder.Services.AddTransient<ILinkRepository, LinkRepository>();

builder.Services.AddCors(options => options.AddPolicy("default", policy =>
{
    policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
}));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();
app.UseCors("default");
//                                          .AllowAnyMethod()
//                                          .AllowAnyHeader());

app.MapControllers();

app.Run();
