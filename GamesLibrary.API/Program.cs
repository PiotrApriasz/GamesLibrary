using FluentValidation;
using FluentValidation.AspNetCore;
using GamesLibrary.API;
using GamesLibrary.API.Entities;
using GamesLibrary.API.Middleware;
using GamesLibrary.API.Services.Account;
using GamesLibrary.API.Validators;
using GamesLibrary.Shared;
using GamesLibrary.Shared.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetService<IConfiguration>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<GamesDbContext>();

// Add custom validation error response

builder.Services.AddMvc().ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = c =>
    {
        var errors = string.Join(" | ", c.ModelState.Values.Where(v => v.Errors.Count > 0)
        .SelectMany(v => v.Errors)
        .Select(v => v.ErrorMessage));

        return new BadRequestObjectResult(new BaseResponse
        {
            Error = true,
            Message = errors
        });
    };
});

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "GamesLibrary.API", Version = "v1" });
});

builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services.AddControllers().AddFluentValidation();

builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddScoped<IValidator<UserRegisterRequest>, RegisterUserValidator>();
builder.Services.AddScoped<IAccountService, AccountService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GamesLibrary.API v1"));
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
