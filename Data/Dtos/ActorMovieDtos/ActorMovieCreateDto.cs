using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos.ActorMovieDtos
{
    public class ActorMovieCreateDto
    {
        [Required]
        public int ActorId { get; set; }
        [Required]
        public int MovieId { get; set; }
    }
}
