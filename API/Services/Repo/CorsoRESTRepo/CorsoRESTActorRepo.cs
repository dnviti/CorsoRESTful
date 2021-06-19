using Data.Context;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.Repo.CorsoRESTRepo
{
    public class CorsoRESTActorRepo : IActorService
    {
        private readonly CorsoRESTDbContext _context;

        public CorsoRESTActorRepo(IDbContextFactory<CorsoRESTDbContext> contextFactory)
        {
            _context = contextFactory.CreateDbContext();
        }

        public void CreateActor(Actor Actor)
        {
            if (Actor == null)
            {
                throw new ArgumentNullException(nameof(Actor));
            }

            _context.Actors.Add(Actor);
        }

        public void DeleteActor(Actor Actor)
        {
            if (Actor == null)
            {
                throw new ArgumentNullException(nameof(Actor));
            }

            _context.Actors.Remove(Actor);
        }

        public IEnumerable<Actor> GetAllActors()
        {
            return _context.Actors.ToList();
        }

        public Task<IEnumerable<Actor>> GetAllActorsAsync()
        {
            throw new NotImplementedException();
        }

        public Actor GetActorById(int Id)
        {
            return _context.Actors.FirstOrDefault(p => p.Id == Id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateActor(Actor Actor)
        {
            _context.Actors.Update(Actor);
        }

        public void CreateActorMovie(ActorMovie ActorMovie)
        {
            ActorMovie.Actor = _context.Actors.FirstOrDefault(p=> p.Id == ActorMovie.ActorId);
            ActorMovie.Movie = _context.Movies.FirstOrDefault(p => p.Id == ActorMovie.MovieId);
            _context.ActorMovies.Add(ActorMovie);
        }
    }
}
