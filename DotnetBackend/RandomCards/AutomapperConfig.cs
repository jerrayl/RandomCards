using System.Linq;
using RandomCards.Models;
using RandomCards.Entities;
using AutoMapper;

namespace RandomCards.AutoMapper
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        : this("MyProfile")
        {
        }

        protected AutoMapperProfileConfiguration(string profileName)
        : base(profileName)
        {
            CreateMap<Class, ClassModel>();
            CreateMap<CardModifier, CardModifierModel>()
                .ForMember(dest => dest.Name, m => m.MapFrom(src => src.Modifier.Name))
                .ForMember(dest => dest.Description, m => m.MapFrom(src => src.Modifier.Description))
                .ForMember(dest => dest.Value, m => m.MapFrom(src => src.Modifier.Value));                
            CreateMap<Card, CardModel>();
        }
    }
}

