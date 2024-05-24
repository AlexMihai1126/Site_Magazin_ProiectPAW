using Microsoft.EntityFrameworkCore;
using proiect.ContextModels;
using Microsoft.AspNetCore.Identity;
using proiect.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ProiectDBContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ProiectDB")));

builder.Services.AddDefaultIdentity<DefaultUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<UsersDBContext>();
builder.Services.AddDbContext<UsersDBContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ProiectDB")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
