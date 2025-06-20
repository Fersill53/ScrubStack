using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScrubStack.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddRazorPages(); // For _Host.cshtml
builder.Services.AddServerSideBlazor(); // For Blazor Server rendering
builder.Services.AddBlazoredTypeahead();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthorizationCore();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await SeedData.InitializeAsync(services);
}

// Middleware
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

// Routing endpoints
app.MapRazorPages(); // ✅ Enables _Host.cshtml
app.MapBlazorHub();  // ✅ Enables SignalR connection for Blazor
app.MapFallbackToPage("/_Host"); // ✅ Fallback to Blazor UI

app.Run();
