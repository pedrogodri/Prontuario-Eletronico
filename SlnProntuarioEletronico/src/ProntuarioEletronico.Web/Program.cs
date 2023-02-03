using Microsoft.EntityFrameworkCore;
using ProntuarioEletronico.Application.Service.SQLServerServices;
using ProntuarioEletronico.Domain.IRepositories;
using ProntuarioEletronico.Domain.IServices;
using ProntuarioEletronico.Infra.Data.Context;
using ProntuarioEletronico.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Conect SQL Server
var connectionStringUser = builder.Configuration.GetConnectionString("SQLServerConnection");
builder.Services.AddDbContext<SQLServerContext>
    (options => options.UseSqlServer(connectionStringUser));

// ## Dependency Injection

// Repositories
builder.Services.AddScoped<IMedicalPlanRepository, MedicalPlanRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();

// Services
builder.Services.AddScoped<IMedicalPlanService, MedicalPlanService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IPatientService, PatientService>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
