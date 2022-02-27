using AutoMapper;
using BlazorRCM.Shared.DTOs;
using BlazorRCM.Shared.Utils;
using RCMServerData.Models;

namespace BlazorRCM.Server.Services.Extensions
{
    public static class ConfigureMappingExtension
    {
        public static IServiceCollection ConfigureMapping(this IServiceCollection service)
        {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });

            IMapper mapper = mappingConfig.CreateMapper();

            service.AddSingleton(mapper);

            return service;
        }
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            AllowNullDestinationValues = true;
            AllowNullCollections = true;

            CreateMap<AuthorityType, AuthorityTypeDTO>()
                .ReverseMap();


            CreateMap<Branch, BranchDTO>()
                .ReverseMap();


            CreateMap<Supplier, SupplierDTO>()
                .ReverseMap();


            CreateMap<UserBranchAuthority, UserBranchAuthorityDTO>()
                .ForMember(x => x.UserFullName, y => y.MapFrom(z=>z.User!.FirstName + " " +z.User.LastName));

            CreateMap<UserBranchAuthorityDTO, UserBranchAuthority>();


            CreateMap<User, UserDTO>()
                .ForMember(x => x.Password, y => y.MapFrom(z => PasswordEncrypter.Decrypt(z.Password!)));

            CreateMap<UserDTO, User>()
                .ForMember(x => x.Password, y => y.MapFrom(z => PasswordEncrypter.Encrypt(z.Password!)));



        }
    }
}
