using CodePepperInterview.Contracts.DTO;
using CodePepperInterview.Contracts.IServices;
using CodePepperInterview.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoreLinq;
using AutoMapper;
using System.Threading.Tasks;

namespace CodePepperInterview.Services.Services
{
    public class HardcodedCharacterService : ICharactersService
    {
        private List<CharacterBaseDto> ItemsList { get; set; }
        private IMapper Mapper { get; set; }

        public HardcodedCharacterService(IMapper mapper)
        {
            var testData = TestDataHelper.LoadCharacters();
            ItemsList = testData.characters.ToList();

            var index = 0;

            ItemsList.ForEach(x =>
            {
                x.Id = index;
                index++;
            });
        }

        public async Task Add(CharacterBaseDto inputDto)
        {
            ItemsList.Add(inputDto);
        }

        public async Task<CharacterItemDto> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CharacterItemDto>> List(int page, int pageSize = 10)
        {
            throw new NotImplementedException();
        }

        public async Task Update(CharacterBaseDto inputDto)
        {
            var item = ItemsList.SingleOrDefault(x => x.Id == inputDto.Id);
        }

        public async Task Delete(int id)
        {
            var itemToDelete = ItemsList.SingleOrDefault(x => x.Id == id);
            ItemsList.Remove(itemToDelete);
        }

        public Task UpdateFriends(int id, UpdateFriendsDto inputDto)
        {
            throw new NotImplementedException();
        }
    }
}