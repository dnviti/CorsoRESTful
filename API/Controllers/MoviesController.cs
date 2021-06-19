namespace API.Controllers
{
    // /api/Movies
    //[Route("api/[controller]")]
    [Route("api/Movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private IMovieService _repository;
        private readonly IMapper _mapper;

        public MoviesController(
            IMovieService repository,
            IMapper mapper
        )
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET /api/Movies
        [HttpGet]
        public ActionResult<IEnumerable<MovieReadDto>> GetAllMovies()
        {
            var MovieItems = _repository.GetAllMovies();
            var mapped = _mapper.Map<IEnumerable<MovieReadDto>>(MovieItems);

            return Ok(mapped);
        }

        //GET /api/Movies/{id}
        [HttpGet("{id}", Name = "GetMovieById")]
        public ActionResult<MovieReadDto> GetMovieById(int id)
        {
            var MovieItem = _repository.GetMovieById(id);
            var mapped = _mapper.Map<MovieReadDto>(MovieItem);
            if (MovieItem != null)
            {
                return Ok(mapped);
            }
            return NotFound();
        }

        //GET /api/Movies/{actorId}
        [HttpGet("{actorId}", Name = "GetAllMoviesByActorId")]
        public ActionResult<IEnumerable<MovieReadDto>> GetAllMoviesByActorId(int actorId)
        {
            var MovieItems = _repository.GetAllMoviesByActorId(actorId);
            var mapped = _mapper.Map<IEnumerable<MovieReadDto>>(MovieItems);

            return Ok(mapped);
        }

        //POST /api/Movies
        [HttpPost]
        public ActionResult<MovieReadDto> CreateMovie(MovieCreateDto MovieCreateDto)
        {
            if (MovieCreateDto == null)
            {
                return NotFound();
            }

            var MovieModel = _mapper.Map<Movie>(MovieCreateDto);

            _repository.CreateMovie(MovieModel);
            _repository.SaveChanges();

            var MovieReadDto = _mapper.Map<MovieReadDto>(MovieModel);

            // returns 201 created and the complete uri of the created resource
            // https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.createdatroute?view=aspnetcore-5.0
            return CreatedAtRoute(nameof(GetMovieById), new { MovieReadDto.Id }, MovieReadDto);
        }

        //PUT IS DEPRECATED!
        //PUT /api/Movies/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateMovie(int id, MovieUpdateDto MovieUpdateDto)
        {
            var MovieModelFromRepo = _repository.GetMovieById(id);
            if (MovieModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(MovieUpdateDto, MovieModelFromRepo);

            _repository.UpdateMovie(MovieModelFromRepo);

            _repository.SaveChanges();

            return NoContent(); // 204
        }

        //USE PATCH INSTEAD OF PUT
        //PATCH /api/Movies/{id}
        [HttpPatch("{id}")]
        public ActionResult UpdateMovie(int id, JsonPatchDocument<MovieUpdateDto> jsonPatchDocument)
        {
            var MovieModelFromRepo = _repository.GetMovieById(id);
            if (MovieModelFromRepo == null)
            {
                return NotFound();
            }

            var MovieToPatch = _mapper.Map<MovieUpdateDto>(MovieModelFromRepo);

            jsonPatchDocument.ApplyTo(MovieToPatch, ModelState);

            if (!TryValidateModel(MovieToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(MovieToPatch, MovieModelFromRepo);

            _repository.UpdateMovie(MovieModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE /api/Movies/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id)
        {
            var MovieModelFromRepo = _repository.GetMovieById(id);
            if (MovieModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteMovie(MovieModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}
