using Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IMovieService
    {
        bool SaveChanges();
        IEnumerable<Movie> GetAllMovies();
        Task<IEnumerable<Movie>> GetAllMoviesAsync();
        Movie GetMovieById(long Id);
        void CreateMovie(Movie Movie);
        void UpdateMovie(Movie Movie);
        void DeleteMovie(Movie Movie);
    }
}
