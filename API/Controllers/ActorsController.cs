using AutoMapper;
using Data.Dtos.ActorDtos;
using Data.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Collections.Generic;

namespace API.Controllers
{
    // /api/Actors
    //[Route("api/[controller]")]
    [Route("api/Actors")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private IActorService _repository;
        private readonly IMapper _mapper;

        public ActorsController(
            IActorService repository,
            IMapper mapper
        )
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET /api/Actors
        [HttpGet]
        public ActionResult<IEnumerable<ActorReadDto>> GetAllActors()
        {
            var ActorItems = _repository.GetAllActors();
            var mapped = _mapper.Map<IEnumerable<ActorReadDto>>(ActorItems);
            return Ok(mapped);
        }

        //GET /api/Actors/{id}
        [HttpGet("{id}", Name = "GetActorById")]
        public ActionResult<ActorReadDto> GetActorById(long id)
        {
            var ActorItem = _repository.GetActorById(id);
            var mapped = _mapper.Map<ActorReadDto>(ActorItem);
            if (ActorItem != null)
            {
                return Ok(mapped);
            }
            return NotFound();
        }

        //POST /api/Actors
        [HttpPost]
        public ActionResult<ActorReadDto> CreateActor(ActorCreateDto ActorCreateDto)
        {
            if (ActorCreateDto == null)
            {
                return NotFound();
            }

            var ActorModel = _mapper.Map<Actor>(ActorCreateDto);

            _repository.CreateActor(ActorModel);
            _repository.SaveChanges();

            var ActorReadDto = _mapper.Map<ActorReadDto>(ActorModel);

            // returns 201 created and the complete uri of the created resource
            // https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.createdatroute?view=aspnetcore-5.0
            return CreatedAtRoute(nameof(GetActorById), new { ActorReadDto.Id }, ActorReadDto);
        }

        //PUT IS DEPRECATED!
        //PUT /api/Actors/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateActor(long id, ActorUpdateDto ActorUpdateDto)
        {
            var ActorModelFromRepo = _repository.GetActorById(id);
            if (ActorModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(ActorUpdateDto, ActorModelFromRepo);

            _repository.UpdateActor(ActorModelFromRepo);

            _repository.SaveChanges();

            return NoContent(); // 204
        }

        //USE PATCH INSTEAD OF PUT
        //PATCH /api/Actors/{id}
        [HttpPatch("{id}")]
        public ActionResult UpdateActor(long id, JsonPatchDocument<ActorUpdateDto> jsonPatchDocument)
        {
            var ActorModelFromRepo = _repository.GetActorById(id);
            if (ActorModelFromRepo == null)
            {
                return NotFound();
            }

            var ActorToPatch = _mapper.Map<ActorUpdateDto>(ActorModelFromRepo);

            jsonPatchDocument.ApplyTo(ActorToPatch, ModelState);

            if (!TryValidateModel(ActorToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(ActorToPatch, ActorModelFromRepo);

            _repository.UpdateActor(ActorModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE /api/Actors/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteActor(long id)
        {
            var ActorModelFromRepo = _repository.GetActorById(id);
            if (ActorModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteActor(ActorModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}
