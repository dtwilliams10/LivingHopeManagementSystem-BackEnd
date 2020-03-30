using AutoMapper;
using LHMSAPI.Entities;
using LHMSAPI.Models.Users;

namespace LHMSAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();
        }
    }
}