using AutoMapper;
using Data.Dtos.ShopDtos;
using Data.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Services.Interfaces;
using System.Collections.Generic;

namespace API.Controllers
{
    // /api/Shops
    //[Route("api/[controller]")]
    [Route("api/Shops")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        private IShopService _repository;
        private readonly IMapper _mapper;

        public ShopsController(
            IShopService repository,
            IMapper mapper
        )
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET /api/Shops
        [HttpGet]
        public ActionResult<IEnumerable<ShopReadDto>> GetAllShops()
        {
            var ShopItems = _repository.GetAllShops();
            var mapped = _mapper.Map<IEnumerable<ShopReadDto>>(ShopItems);
            return Ok(mapped);
        }

        //GET /api/Shops/{id}
        [HttpGet("{id}", Name = "GetShopById")]
        public ActionResult<ShopReadDto> GetShopById(int id)
        {
            var ShopItem = _repository.GetShopById(id);
            var mapped = _mapper.Map<ShopReadDto>(ShopItem);
            if (ShopItem != null)
            {
                return Ok(mapped);
            }
            return NotFound();
        }

        //POST /api/Shops
        [HttpPost]
        public ActionResult<ShopReadDto> CreateShop(ShopCreateDto ShopCreateDto)
        {
            if (ShopCreateDto == null)
            {
                return NotFound();
            }

            var ShopModel = _mapper.Map<Shop>(ShopCreateDto);

            _repository.CreateShop(ShopModel);
            _repository.SaveChanges();

            var ShopReadDto = _mapper.Map<ShopReadDto>(ShopModel);

            // returns 201 created and the complete uri of the created resource
            // https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.createdatroute?view=aspnetcore-5.0
            return CreatedAtRoute(nameof(GetShopById), new { ShopReadDto.Id }, ShopReadDto);
        }

        //PUT IS DEPRECATED!
        //PUT /api/Shops/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateShop(int id, ShopUpdateDto ShopUpdateDto)
        {
            var ShopModelFromRepo = _repository.GetShopById(id);
            if (ShopModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(ShopUpdateDto, ShopModelFromRepo);

            _repository.UpdateShop(ShopModelFromRepo);

            _repository.SaveChanges();

            return NoContent(); // 204
        }

        //USE PATCH INSTEAD OF PUT
        //PATCH /api/Shops/{id}
        [HttpPatch("{id}")]
        public ActionResult UpdateShop(int id, JsonPatchDocument<ShopUpdateDto> jsonPatchDocument)
        {
            var ShopModelFromRepo = _repository.GetShopById(id);
            if (ShopModelFromRepo == null)
            {
                return NotFound();
            }

            var ShopToPatch = _mapper.Map<ShopUpdateDto>(ShopModelFromRepo);

            jsonPatchDocument.ApplyTo(ShopToPatch, ModelState);

            if (!TryValidateModel(ShopToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(ShopToPatch, ShopModelFromRepo);

            _repository.UpdateShop(ShopModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE /api/Shops/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteShop(int id)
        {
            var ShopModelFromRepo = _repository.GetShopById(id);
            if (ShopModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteShop(ShopModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}
