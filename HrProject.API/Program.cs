using FluentValidation;
using HrProject.API.Validator.EmployeeValidator;
using HrProject.Business.Abstract;
using HrProject.Business.Concrete;
using HrProject.DataAccess.Abstract;
using HrProject.DataAccess.Concrete;
using HrProject.DataAccess.Context;
using HrProject.DataAccess.UnitOfWork;
using HrProject.DTOs.CreateDTO;
using HrProject.DTOs.UpdateDTO;
using HrProject.Entities.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<HrProjectContext>(
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DbContext")));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped<IDemandService, DemandService>();
builder.Services.AddScoped<IUow, Uow>();
builder.Services.AddTransient<IValidator<UpdateEmployeeDTO>, UpdateEmployeeDTOValidator>();
builder.Services.AddTransient<IValidator<CreatePermissionDTO>, CreatePermissionDTOValidator>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = true;
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidIssuer = "https://localhost",
        ValidAudience = "https://localhost",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("HRProjectTeam123456789012345")),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});
builder.Services.AddIdentity<AppUser, AppRole>().AddDefaultTokenProviders().AddEntityFrameworkStores<HrProjectContext>().AddSignInManager<SignInManager<AppUser>>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//BU CADONUN BRACNHI

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
