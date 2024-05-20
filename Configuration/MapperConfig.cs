using AutoMapper;
using RESTAPI.Data;
using RESTAPI.DTO;

namespace RESTAPI.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<User, UserPatchDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserSignupDTO>().ReverseMap();
        }
    }
}
