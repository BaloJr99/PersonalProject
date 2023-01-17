using Microsoft.EntityFrameworkCore;
using PersonalProject.Business.IUnitOfWork.Interfaces;
using PersonalProject.Business.IUnitOfWork.Services;
using PersonalProject.Business.Repositories.Interfaces;
using PersonalProject.Business.Repositories.Services;
using PersonalProject.Data.Models;
using AutoMapper;
using PersonalProject.Business.Interfaces;
using PersonalProject.Business.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using PersonalProject.Client.Middleware;
using PersonalProject.Common;
using PersonalProject.Data.DTO;
using Microsoft.AspNetCore.Identity;

//Create a new config to get the connection string
var getConfig = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

IConfiguration _configuration = getConfig.Build();

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddConfiguration(_configuration);
var automapper = new MapperConfiguration(cfg => {
    cfg.AddProfile(new AutomapperProfile());
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters(){
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.AddAuthorization();
IMapper mapper = automapper.CreateMapper();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddSingleton(mapper);
builder.Services.AddScoped<IJwtUtils, JwtUtils>();
builder.Services.AddScoped<IUnitOfWorkPersonal, UnitOfWork>();
builder.Services.AddScoped<IAuthenticateService, AuthenticateService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IMedicalAppointmentsService, MedicalAppointmentsService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddDbContext<MedicalContext>(options => {
    options.UseSqlServer(_configuration.GetConnectionString("MedicalContext"));
    //Enable to get Error messages from the server
    options.EnableSensitiveDataLogging();
}, ServiceLifetime.Transient);
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();  

app.UseMiddleware<MyAuthenticationMiddleware>();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
