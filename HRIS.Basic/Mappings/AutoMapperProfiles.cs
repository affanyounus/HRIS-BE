using AutoMapper;
using HRIS.Basic.Models.Domain;
using HRIS.Basic.Models.DTO.User;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace HRIS.Basic.Mappings
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {

            //var configuration = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<User, UserDTO>()
            //        //.ForMember(dest=>dest, act=> act.Ignore())
            //        //.ForMember(dest=> dest.Email, act=> act.Ignore())
            //        .ReverseMap();


            //});



            //configuration.AssertConfigurationIsValid();

            CreateMap<User, UserDTO>()
                //.ForMember(dest=> dest.Email, act=> act.Ignore())
                .ReverseMap();


            CreateMap<UserRequestDTO, User>().ReverseMap();


        }
    }
}
