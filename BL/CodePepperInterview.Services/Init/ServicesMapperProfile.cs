using AutoMapper;
using CodePepperInterview.Contracts.DTO;
using CodePepperInterview.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePepperInterview.Services.Init
{
    public class ServicesMapperProfile : Profile
    {
        public ServicesMapperProfile()
        {
            CreateMap<CharacterBaseDto, CharacterBaseDto>()
                .ForMember(dst => dst.Id, src => src.Ignore());

            CreateMap<CharacterBaseDto, Character>()
               .ForMember(dst => dst.Id, src => src.Ignore());

            CreateMap<Character, CharacterBaseDto>();

            CreateMap<Character, CharacterItemDto>()
                .ForMember(dst => dst.friends, src => src.Ignore())
                .AfterMap((src, dst) =>
                {
                    if (src.CharacterFriendRelatingCharacter == null)
                    {
                        return;
                    }
                    var friends = src.CharacterFriendRelatingCharacter.Select(x => x.RelatedCharacter);
                    var names = friends.Select(x => x.Name);

                    dst.friends = names;
                });
        }
    }
}