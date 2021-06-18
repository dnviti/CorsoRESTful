using Data.Context;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onyce.Services.Data.Repo.SqlServer
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

        public Movie GetMovieById(long Id)
        {
            return _context.Movies.FirstOrDefault(p => p.Id == Id);
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
