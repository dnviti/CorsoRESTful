using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos.ActorMovieDtos
{
    public class ActorMovieReadDto
    {
        public Actor Actor { get; set; }
        public Movie Movie { get; set; }
    }
}
