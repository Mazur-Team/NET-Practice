namespace NETPractice.BLL;

using Models;

public class MovieService {
    private readonly IMovieRepository _repository;

    public MovieService(IMovieRepository repository) {
        _repository = repository;
    }

    public async Task<IEnumerable<Movie>> GetMoviesAsync() {
        var movies = await _repository.GetAllAsync();
        Console.WriteLine($"Movies retrieved in service: {movies.Count()}"); // Вивід у консоль для перевірки
        return movies;
    }
    public async Task<Movie?> GetMovieByIdAsync(int id) => await _repository.GetByIdAsync(id);
    public async Task AddMovieAsync(Movie movie) => await _repository.AddAsync(movie);
    public async Task UpdateMovieAsync(Movie movie) => await _repository.UpdateAsync(movie);
    public async Task DeleteMovieAsync(int id) => await _repository.DeleteAsync(id);
}
