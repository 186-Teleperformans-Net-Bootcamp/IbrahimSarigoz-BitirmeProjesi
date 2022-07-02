using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ShoppingList.Application.Validators.ShopLists;
using ShoppingList.Infrastructure.Filters;
using ShoppingList.Persistence;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;


//persistence içindeki tüm servisler IoC ye eklenmiþ oldu. 
builder.Services.AddPersistanceServices();


builder.Services.AddControllers(options=> options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configuration=>configuration.RegisterValidatorsFromAssemblyContaining<CreateShopListValidator>());



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
