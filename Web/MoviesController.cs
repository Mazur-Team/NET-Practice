using Microsoft.AspNetCore.Mvc;
using NETPractice.BLL;
using NETPractice.Models;
public class MoviesController : Controller {
    private readonly MovieService _movieService;

    public MoviesController(MovieService movieService) {
        _movieService = movieService;
    }

    public async Task<IActionResult> Index() {
        var movies = await _movieService.GetMoviesAsync();
        Console.WriteLine($"Movies retrieved: {movies.Count()}"); // Перевірка
        return View(movies);
    }


    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Movie movie) {
        if (ModelState.IsValid) {
            await _movieService.AddMovieAsync(movie);
            return RedirectToAction("Index");
        }
        return View(movie);
    }
}