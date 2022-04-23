using AutoMapper;
using BlazorRCM.Shared.DTOs.ModelDTOs;
using Microsoft.Extensions.DependencyInjection;
using RCMServerData.Models;

namespace BlazorRCM.Shared.Extensions
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
            
            CreateMap<SupplierFirmType, SupplierFirmTypeDTO>()
                .ForMember(x=>x.SupplierName, y=>y.MapFrom(z=>z.Supplier!.CompanyName))
                .ForMember(x=>x.FirmType, y=>y.MapFrom(z=>z.FirmType!.Name))
                .ForMember(x=>x.CreatedBy, y=>y.MapFrom(z => z.UserCB!.FirstName + " " + z.UserCB.LastName))
                .ForMember(x=>x.ModifiedBy, y=>y.MapFrom(z => z.UserMB!.FirstName + " " + z.UserMB.LastName))
                .ReverseMap();

            CreateMap<User, UserDTO>()
            .ReverseMap();

            CreateMap<UserBranchAuthority, UserBranchAuthorityDTO>()
                //.Include<User, UserDTO>()
                .ForMember(x => x.UserFullName, y => y.MapFrom(z => z.User!.FirstName + " " + z.User.LastName))
                .ForMember(x => x.BranchName, y => y.MapFrom(z => z.Branch!.Name))
                .ForMember(x => x.AuthorityTypeName, y => y.MapFrom(z => z.AuthorityType!.Type));
            //.ReverseMap();

            CreateMap<UserBranchAuthorityDTO, UserBranchAuthority>();
                //.ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                //.ForMember(x => x.UId, y => y.MapFrom(z => z.UId))
                //.ForMember(x => x.BId, y => y.MapFrom(z => z.BId))
                //.ForMember(x => x.ATId, y => y.MapFrom(z => z.ATId));


            CreateMap<FirmType, FirmTypeDTO>()
                .ReverseMap();
            //CreateMap<UserBranchAuthorityDTO, UserBranchAuthority>();


            //CreateMap<User, UserDTO>()
            //    .ForMember(x => x.Password, y => y.MapFrom(z => PasswordEncrypter.Decrypt(z.Password!)));

            //CreateMap<UserDTO, User>()
            //    .ForMember(x => x.Password, y => y.MapFrom(z => PasswordEncrypter.Encrypt(z.Password!)));

            CreateMap<BranchProductPrice, BranchProductPriceDTO>()
                //.Include<User, UserDTO>()
                .ForMember(x => x.ProductName, y => y.MapFrom(z => z.Product!.Name))
                .ForMember(x => x.ColorCode, y => y.MapFrom(z => z.Product!.ColorCode))
                .ForMember(x => x.MenuListId, y => y.MapFrom(z => z.Product!.MenuListId))
                .ReverseMap();

        }
    }
}
