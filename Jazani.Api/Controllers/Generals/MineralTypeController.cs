using Jazani.Application.Generals.Dtos.MineralTypes;
using Jazani.Application.Generals.Services;
using Microsoft.AspNetCore.Mvc;
using Jazani.Api.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Generals
{
    [Route("api/[controller]")]
    public class MineralTypeController : ControllerBase
    {
        private readonly IMineralTypeService _mineralTypeService;

        public MineralTypeController(IMineralTypeService mineralTypeService)
        {
            _mineralTypeService = mineralTypeService;
        }

        // GET: api/<MineralTypeController>
        [HttpGet]
        public async Task<IEnumerable<MineralTypeDto>> Get()
        {
            return await _mineralTypeService.FindAllAsync();
        }

        // GET api/<MineralTypeController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MineralTypeDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<NotFound, Ok<MineralTypeDto>>> Get(int id)
        {
            var response = await _mineralTypeService.FindByIdAsync(id);

            return TypedResults.Ok(response);
        }

        // POST api/<MineralTypeController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MineralTypeDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<MineralTypeDto>>> Post([FromBody] MineralTypeSavaDto savaDto)
        {
            var response = await _mineralTypeService.CreateAsync(savaDto);
            return TypedResults.CreatedAtRoute(response);
        }

        // PUT api/<MineralTypeController>/5
        [HttpPut("{id}")]
        public async Task<MineralTypeDto> Put(int id, [FromBody] MineralTypeSavaDto savaDto)
        {
            return await _mineralTypeService.EditAsync(id, savaDto);
        }

        // DELETE api/<MineralTypeController>/5
        [HttpDelete("{id}")]
        public async Task<MineralTypeDto> Delete(int id)
        {
            return await _mineralTypeService.DisabledAsync(id);
        }
    }
}
