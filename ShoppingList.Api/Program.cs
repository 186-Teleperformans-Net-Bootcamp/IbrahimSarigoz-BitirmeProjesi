using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Admin", options =>
     {
         options.TokenValidationParameters = new()
         {
             ValidateAudience = true, 
             ValidateIssuer = true,
             ValidateLifetime= true,
             ValidateIssuerSigningKey = true,

             ValidAudience = configuration["Token:Audience"],
             ValidIssuer = configuration["Token:Issuer"],
             IssuerSigningKey =  new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:SigningKey"]))



         };



     });
var app = builder.Build();


app.UseAuthentication();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
