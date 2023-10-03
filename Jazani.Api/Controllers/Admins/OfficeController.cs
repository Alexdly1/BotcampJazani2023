using Jazani.Application.Admins.Dtos.Offices;
using Jazani.Application.Admins.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly IOfficeService _officeService;

        public OfficeController(IOfficeService officeService)
        {
            _officeService = officeService;
        }


        // GET: api/<OfficeController>
        [HttpGet]
        public async Task<IEnumerable<OfficeDto>> Get()
        {
            return await _officeService.FindAllAsync();
        }

        // GET api/<OfficeController>/5
        [HttpGet("{id}")]
        public async Task<OfficeDto> Get(int id)
        {
            return await _officeService.FindByIdAsync(id);
        }

        // POST api/<OfficeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OfficeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OfficeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
