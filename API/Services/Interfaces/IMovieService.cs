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
        Movie GetMovieById(int Id);
        void CreateMovie(Movie Movie);
        void UpdateMovie(Movie Movie);
        void DeleteMovie(Movie Movie);
        IEnumerable<Movie> GetAllMoviesByActorId(int ActorId);
    }
}
