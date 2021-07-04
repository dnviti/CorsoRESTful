using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Model;

namespace Services.Interfaces
{
    public interface IActorService
    {
        bool SaveChanges();
        IEnumerable<Actor> GetAllActors();
        Task<IEnumerable<Actor>> GetAllActorsAsync();
        Actor GetActorById(int Id);
        void CreateActor(Actor Actor);
        void UpdateActor(Actor Actor);
        void DeleteActor(Actor Actor);
        void CreateActorMovie(ActorMovie ActorMovie);
    }
}
