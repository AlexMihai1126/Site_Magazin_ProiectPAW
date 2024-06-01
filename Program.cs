using Microsoft.EntityFrameworkCore;
using proiect.ContextModels;
using Microsoft.AspNetCore.Identity;
using proiect.Models;
using Microsoft.AspNetCore.Http;
using proiect.Services;

var builder = WebApplication.CreateBuilder(args);

// Adaugă servicii la container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ProiectDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProiectDB")));

builder.Services.AddDefaultIdentity<DefaultUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ProiectDBContext>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();

builder.Services.AddScoped<ShoppingCartService>();

// Înregistrează IndexModel ca un serviciu
builder.Services.AddScoped<proiect.Pages.Telefoane.IndexModel>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapRazorPages();

app.MapPost("/Telefoane/AddToCart", async context =>
{
    var handler = context.RequestServices.GetRequiredService<proiect.Pages.Telefoane.IndexModel>();
    var request = await context.Request.ReadFromJsonAsync<proiect.Pages.Telefoane.IndexModel.AddToCartRequest>();
    await handler.OnPostAddToCartAsync(request);
}).RequireAuthorization(); // Optionally, require authorization for this action

app.Run();
