using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodePepperInterview.Contracts.DTO;
using CodePepperInterview.Contracts.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodePepperInterview.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private ICharactersService CharactersService { get; set; }

        public CharacterController(ICharactersService charactersService)
        {
            CharactersService = charactersService;
        }

        // GET: api/Character
        [HttpGet]
        public async Task<IEnumerable<CharacterItemDto>> Get()
        {
            return await CharactersService.List(0, 100);
        }

        // GET: api/Character/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<CharacterItemDto> Get(int id)
        {
            return await CharactersService.Get(id);
        }

        // POST: api/Character
        [HttpPost]
        public async Task Post([FromBody] CharacterBaseDto value)
        {
            await CharactersService.Add(value);
        }

        // PUT: api/Character/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] CharacterBaseDto value)
        {
            value.Id = id;
            await CharactersService.Update(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await CharactersService.Delete(id);
        }
    }
}