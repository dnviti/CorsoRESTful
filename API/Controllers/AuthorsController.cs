namespace API.Controllers
{
    // /api/Authors
    //[Route("api/[controller]")]
    [Route("api/Authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private IAuthorService _repository;
        private readonly IMapper _mapper;

        public AuthorsController(
            IAuthorService repository,
            IMapper mapper
        )
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET /api/Authors
        [HttpGet]
        public ActionResult<IEnumerable<AuthorReadDto>> GetAllAuthors()
        {
            var AuthorItems = _repository.GetAllAuthors();
            var mapped = _mapper.Map<IEnumerable<AuthorReadDto>>(AuthorItems);
            return Ok(mapped);
        }

        //GET /api/Authors/{id}
        [HttpGet("{id}", Name = "GetAuthorById")]
        public ActionResult<AuthorReadDto> GetAuthorById(int id)
        {
            var AuthorItem = _repository.GetAuthorById(id);
            var mapped = _mapper.Map<AuthorReadDto>(AuthorItem);
            if (AuthorItem != null)
            {
                return Ok(mapped);
            }
            return NotFound();
        }

        //POST /api/Authors
        [HttpPost]
        public ActionResult<AuthorReadDto> CreateAuthor(AuthorCreateDto AuthorCreateDto)
        {
            if (AuthorCreateDto == null)
            {
                return NotFound();
            }

            var AuthorModel = _mapper.Map<Author>(AuthorCreateDto);

            _repository.CreateAuthor(AuthorModel);
            _repository.SaveChanges();

            var AuthorReadDto = _mapper.Map<AuthorReadDto>(AuthorModel);

            // returns 201 created and the complete uri of the created resource
            // https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.createdatroute?view=aspnetcore-5.0
            return CreatedAtRoute(nameof(GetAuthorById), new { AuthorReadDto.Id }, AuthorReadDto);
        }

        //PUT IS DEPRECATED!
        //PUT /api/Authors/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateAuthor(int id, AuthorUpdateDto AuthorUpdateDto)
        {
            var AuthorModelFromRepo = _repository.GetAuthorById(id);
            if (AuthorModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(AuthorUpdateDto, AuthorModelFromRepo);

            _repository.UpdateAuthor(AuthorModelFromRepo);

            _repository.SaveChanges();

            return NoContent(); // 204
        }

        //USE PATCH INSTEAD OF PUT
        //PATCH /api/Authors/{id}
        [HttpPatch("{id}")]
        public ActionResult UpdateAuthor(int id, JsonPatchDocument<AuthorUpdateDto> jsonPatchDocument)
        {
            var AuthorModelFromRepo = _repository.GetAuthorById(id);
            if (AuthorModelFromRepo == null)
            {
                return NotFound();
            }

            var AuthorToPatch = _mapper.Map<AuthorUpdateDto>(AuthorModelFromRepo);

            jsonPatchDocument.ApplyTo(AuthorToPatch, ModelState);

            if (!TryValidateModel(AuthorToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(AuthorToPatch, AuthorModelFromRepo);

            _repository.UpdateAuthor(AuthorModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE /api/Authors/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteAuthor(int id)
        {
            var AuthorModelFromRepo = _repository.GetAuthorById(id);
            if (AuthorModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteAuthor(AuthorModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}
