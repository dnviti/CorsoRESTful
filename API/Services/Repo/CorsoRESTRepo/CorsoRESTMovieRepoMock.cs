using Data.Model;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.Repo.CorsoRESTRepo
{
    public class CorsoRESTMovieRepoMock : IMovieService
    {
        public void CreateMovie(Movie Movie)
        {
            throw new NotImplementedException();
        }

        public void DeleteMovie(Movie Movie)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return new List<Movie> {
                new Movie{ Id = 1, CreatedOn = DateTime.Now }
            };
        }

        public Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetAllMoviesByActorId(int ActorId)
        {
            throw new NotImplementedException();
        }

        public Movie GetMovieById(int Id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateMovie(Movie Movie)
        {
            throw new NotImplementedException();
        }
    }
}
