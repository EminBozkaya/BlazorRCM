using AutoMapper;
using BlazorRCM.Shared.DTOs;
using Core.BaseService.EF;
using RCMServerData.EFContext;
using RCMServerData.Models;
using RCMServerData.Repositories.Abstract;

namespace RCMServerData.Repositories.Concrete.EF
{
    public class EfSupplierRepo : EfRepositoryBase<RCMBlazorContext, Supplier, SupplierDTO>, ISupplierRepo

    {
        public EfSupplierRepo(IMapper Mapper) : base(Mapper)
        {
        }
    }
}
