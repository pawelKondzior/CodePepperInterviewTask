using CodePepperInterview.Contracts.DTO;
using CodePepperInterview.Contracts.IServices;
using CodePepperInterview.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoreLinq;
using AutoMapper;
using URF.Core.EF;
using URF.Core.Abstractions;
using CodePepperInterview.DAL.Models;
using URF.Core.Services;
using URF.Core.Abstractions.Trackable;
using CodePepperInterview.DAL.EF.Contexts;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CodePepperInterview.Services.Services
{
    public class CharacterService :// Service<Character>,
        ICharactersService

    {
        private IMapper mapper;
        private IUnitOfWork unitOfWork;
        private ITrackableRepository<Character> repository;
        private ITrackableRepository<CharacterFriend> friendRepo;

        //public CharacterService, private IUnitOfWork unitOfWork)
        //{
        //    Mapper = mapper;
        //}

        public CharacterService(
            ITrackableRepository<Character> repository,
            ITrackableRepository<CharacterFriend> friendRepository,
            IUnitOfWork unitOfWork
            , IMapper mapper)

        {
            this.repository = repository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.friendRepo = friendRepository;
        }

        public async Task Add(CharacterBaseDto inputDto)
        {
            var character = this.mapper.Map<Character>(inputDto);

            repository.Insert(character);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task Update(CharacterBaseDto inputDto)
        {
            var character = this.mapper.Map<Character>(inputDto);
            character.Id = inputDto.Id;

            repository.Update(character);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<CharacterItemDto> Get(int id)
        {
            var entity = repository.Queryable()
                .Include(x => x.CharacterFriendRelatingCharacter)
                 .ThenInclude(frinds => frinds.RelatedCharacter)
                 .FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                throw new NullReferenceException("entity == null in Get(int id)");
            }

            var result = mapper.Map<CharacterItemDto>(entity);

            return result;
        }

        public async Task<IEnumerable<CharacterItemDto>> List(int page, int pageSize = 10)
        {
            var entities = repository.Queryable()
                    .Include(x => x.CharacterFriendRelatingCharacter)
                    .ThenInclude(frinds => frinds.RelatedCharacter)
                    .Skip(pageSize * page)
                    .Take(pageSize)
                    .ToList();

            var result = mapper.Map<List<CharacterItemDto>>(entities);

            return result;
        }

        public async Task UpdateFriends(int id, UpdateFriendsDto inputDto)
        {
            var toDelete = friendRepo.Queryable()
                .Where(x => x.RelatedCharacterId == id || x.RelatingCharacterId == id)
                .ToList();

            toDelete.ForEach(friendRepo.Delete);

            var toAdd = new List<CharacterFriend>();
            inputDto.Friends.ForEach(friendId =>
            {
                toAdd.Add(new CharacterFriend(id, friendId));
                toAdd.Add(new CharacterFriend(friendId, id));
            });

            toAdd.ForEach(friendRepo.Insert);

            await unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var result = await repository.DeleteAsync(id);

            await unitOfWork.SaveChangesAsync();
        }
    }
}