using NETPractice.BLL;
using NETPractice.DAL;
using NETPractice.Models;

var builder = WebApplication.CreateBuilder(args);

// Підключення до бази даних
// builder.Services.AddDbContext<CinemaContext>(options =>
//     options.UseSqlServer("YourConnectionString"));

// Реєстрація залежностей
// builder.Services.AddScoped<IMovieRepository, MovieRepository>();
// builder.Services.AddScoped<MovieService>();

// Fake Repo
builder.Services.AddScoped<IMovieRepository, InMemoryMovieRepository>();
builder.Services.AddScoped<MovieService>();


// Додайте MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Додавання тестових даних
using (var scope = app.Services.CreateScope()) {
    var repo = scope.ServiceProvider.GetRequiredService<IMovieRepository>() as InMemoryMovieRepository;
    repo?.AddTestData();
}

// Налаштування середовища
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies}/{action=Index}/{id?}");

app.Run();

// var builder = WebApplication.CreateBuilder(args);
//
// // Реєстрація сервісів
// builder.Services.AddScoped<IMovieRepository, InMemoryMovieRepository>();
// builder.Services.AddScoped<MovieService>();
//
// builder.Services.AddControllersWithViews();
//
// var app = builder.Build();
//
// // Додавання тестових даних
// using (var scope = app.Services.CreateScope()) {
//     var repo = scope.ServiceProvider.GetRequiredService<IMovieRepository>() as InMemoryMovieRepository;
//     repo?.AddTestData();
//     Console.WriteLine("Test data added to repository.");
// }
//
// // Налаштування середовища
// app.UseRouting();
// app.UseStaticFiles();
// app.UseEndpoints(endpoints => {
//     endpoints.MapControllerRoute(
//         name: "default",
//         pattern: "{controller=Movies}/{action=Index}/{id?}");
// });
//
// app.Run();

