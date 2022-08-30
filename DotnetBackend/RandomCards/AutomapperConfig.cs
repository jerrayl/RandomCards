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
        }
    }
}

