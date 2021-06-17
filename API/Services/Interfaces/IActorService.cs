using Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IActorService
    {
        bool SaveChanges();
        IEnumerable<Actor> GetAllActors();
        Task<IEnumerable<Actor>> GetAllActorsAsync();
        Actor GetActorById(long Id);
        void CreateActor(Actor Actor);
        void UpdateActor(Actor Actor);
        void DeleteActor(Actor Actor);
    }
}
