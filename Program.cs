using StudentRegistration.Services;

var builder = WebApplication.CreateBuilder(args);

// MVC + in-memory data store (singleton so data lives while the app runs)
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IStudentRepository, InMemoryStudentRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();

// Conventional routing: /{controller}/{action}/{id?}
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
