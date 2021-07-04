using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
namespace API.Services.Repo.CorsoRESTRepo
{
    public class CorsoRESTMovieRepo : IMovieService
    {
        private readonly CorsoRESTDbContext _context;

        public CorsoRESTMovieRepo(IDbContextFactory<CorsoRESTDbContext> contextFactory)
        {
            _context = contextFactory.CreateDbContext();
        }

        public void CreateMovie(Movie Movie)
        {
            if (Movie == null)
            {
                throw new ArgumentNullException(nameof(Movie));
            }

            _context.Movies.Add(Movie);
        }

        public void DeleteMovie(Movie Movie)
        {
            if (Movie == null)
            {
                throw new ArgumentNullException(nameof(Movie));
            }

            _context.Movies.Remove(Movie);
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }

        public Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            throw new NotImplementedException();
        }

        public Movie GetMovieById(int Id)
        {
            /*
             * LINQ => Query Syntax
             * Stesso risultato dell'espressione sotto, diversa sintassi
            var movie = (from m in _context.Movies
                        where m.Id == Id
                        select m).FirstOrDefault();
            */
            // LINQ => Lambda Expression
            return _context.Movies.FirstOrDefault(p => p.Id == Id);
        }

        public IEnumerable<Movie> GetAllMoviesByActorId(int ActorId)
        {
            var movies =
                from m in _context.Movies
                join a in _context.Actors on m.Id equals a.Id
                where a.Id == ActorId
                select m;

            return movies.ToList();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateMovie(Movie Movie)
        {
            //Nothing
        }
    }
}
