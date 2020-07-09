using CodePepperInterview.Contracts.DTO;
using CodePepperInterview.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using URF.Core.Abstractions.Services;

namespace CodePepperInterview.Contracts.IServices
{
    public interface ICharactersService
    {
        Task Add(CharacterBaseDto inputDto);

        Task Update(CharacterBaseDto inputDto);

        Task Delete(int id);

        Task<CharacterItemDto> Get(int id);

        Task<IEnumerable<CharacterItemDto>> List(int page, int pageSize = 10);

        Task UpdateFriends(int id, UpdateFriendsDto inputDto);
    }
}