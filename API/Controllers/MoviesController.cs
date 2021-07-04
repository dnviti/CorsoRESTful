using System.Collections.Generic;
using API.Helpers.Utilities;
using AutoMapper;
using Data.Dtos.MovieDtos;
using Data.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
namespace API.Controllers
{
    // /api/Movies
    //[Route("api/[controller]")]
    [Route("api/Movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _repository;
        private readonly IMapper _mapper;

        public UrlHelper UrlHelper { get; }

        public MoviesController(
            IMovieService repository,
            IMapper mapper,
            UrlHelper urlHelper
        )
        {
            _repository = repository;
            _mapper = mapper;
            UrlHelper = urlHelper;
        }

        //GET /api/Movies
        [HttpGet]
        public ActionResult<IEnumerable<MovieReadDto>> GetAllMovies([FromHeader(Name = "Accept")] string accept)
        {
            var MovieItems = _repository.GetAllMovies();
            var mapped = _mapper.Map<IEnumerable<MovieReadDto>>(MovieItems);

            // Add links if requested by client
            if (accept.EndsWith("hateoas"))
            {
                foreach (MovieReadDto movieReadDto in mapped)
                {
                    var link = new LinkHelper<MovieReadDto>(movieReadDto);
                    link.Links.Add(new Link
                    {
                        Href = $"{UrlHelper.BaseUrlGenerator(HttpContext)}/api/Movies/{movieReadDto.Id}",
                        Rel = "self",
                        method = "GET"
                    });
                    link.Links.Add(new Link
                    {
                        Href = $"{UrlHelper.BaseUrlGenerator(HttpContext)}/api/Movies/{movieReadDto.Id}",
                        Rel = "update-movie",
                        method = "PUT"
                    });
                    link.Links.Add(new Link
                    {
                        Href = $"{UrlHelper.BaseUrlGenerator(HttpContext)}/api/Movies/{movieReadDto.Id}",
                        Rel = "delete-movie",
                        method = "DELETE"
                    });
                    movieReadDto.Links = link.Links;
                }
            }

            return Ok(mapped);
        }

        //GET /api/Movies/GetMovieById/{id}
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

        //GET /api/Movies/ByActor?actorId={id}
        [Route("ByActor")]
        [HttpGet]
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
