using Microsoft.EntityFrameworkCore;
using PhotoSharingApplication.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PhotoSharingContext>(options =>
    options.UseSqlServer(builder.Configuration
        .GetConnectionString("PhotoSharingDB")));

var app = builder.Build();

// Q14 — Remplace Database.SetInitializer + Application_Start
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider
        .GetRequiredService<PhotoSharingContext>();
    PhotoSharingInitializer.Initialize(context);  // appel du Seed
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();