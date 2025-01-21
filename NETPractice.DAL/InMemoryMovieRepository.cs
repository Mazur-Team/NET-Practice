using System.Collections.Concurrent;
using NETPractice.Models;

namespace NETPractice.DAL;

public class InMemoryMovieRepository : IMovieRepository
{
    private readonly Dictionary<int, Movie> _movies = new();
    private int _currentId = 1;

    public void AddTestData()
    {
        var testMovies = new List<Movie>
        {
            new Movie
            {
                Title = "Inception", Description = "A mind-bending thriller", Genre = "Sci-Fi",
                ReleaseDate = new DateTime(2010, 7, 16)
            },
            new Movie
            {
                Title = "The Dark Knight", Description = "A Batman story", Genre = "Action",
                ReleaseDate = new DateTime(2008, 7, 18)
            }
        };

        foreach (var movie in testMovies)
        {
            movie.Id = _currentId++;
            _movies[movie.Id] = movie;
            Console.WriteLine($"Added movie: {movie.Title}, ID: {movie.Id}");
        }
    }

    public Task<IEnumerable<Movie>> GetAllAsync()
    {
        Console.WriteLine($"Movies count in repository: {_movies.Count}");
        foreach (var movie in _movies.Values)
        {
            Console.WriteLine($"Movie in repository: {movie.Title}");
        }

        return Task.FromResult(_movies.Values.AsEnumerable());
    }


    public Task<Movie?> GetByIdAsync(int id)
    {
        _movies.TryGetValue(id, out var movie);
        return Task.FromResult(movie);
    }

    public Task AddAsync(Movie movie)
    {
        movie.Id = _currentId++;
        _movies[movie.Id] = movie;
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Movie movie)
    {
        if (_movies.ContainsKey(movie.Id))
        {
            _movies[movie.Id] = movie;
        }

        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        _movies.Remove(id, out _);
        return Task.CompletedTask;
    }
}
