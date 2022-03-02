using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;
using BlazorRCM.Shared.DTOs;

namespace RCM.Business.Concrete
{
    public class UserBs : BusinessService<UserDTO>
    {
        private readonly IUserRepo _repo;

        public UserBs(IUserRepo repo)
            : base(repo)
        {
            _repo = repo;
        }

        //---------special methods-(about user)----------
        //public User GetByEmail(string email, params string[] includeList)
        //{
        //    return _repo.Get(x => x.Email == email, includeList);
        //}

        //public User GetByEmailAndPassword(string email, string password, params string[] includeList)
        //{
        //    return _repo.Get(x => x.Email == email && x.Password == password, includeList);
        //}
    }
}
