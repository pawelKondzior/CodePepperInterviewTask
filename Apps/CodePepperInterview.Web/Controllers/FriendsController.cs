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
    [Route("api/Character")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        private ICharactersService CharactersService { get; set; }

        public FriendsController(ICharactersService charactersService)
        {
            CharactersService = charactersService;
        }

        [HttpPut]
        [Route("{id}/friends")]
        public async Task Put(int id, [FromBody] UpdateFriendsDto value)
        {
            await CharactersService.UpdateFriends(id, value);
        }
    }
}