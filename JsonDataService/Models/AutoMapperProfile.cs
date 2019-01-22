using AutoMapper;
using JsonDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonDataService.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Person, PersonModel>()
                .ForMember(x => x.Tags, y => y.MapFrom(z => z.Tags.Split(',')))
                .ReverseMap()
                .ForMember(x => x.Tags, y => y.MapFrom(z => String.Join(",", z.Tags)));

            CreateMap<Friend, FriendModel>().ReverseMap();
        }
    }
}