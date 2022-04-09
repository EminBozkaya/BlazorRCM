using AutoMapper;
using BlazorRCM.Server.Infrasructures;
using BlazorRCM.Shared.DTOs;
using BlazorRCM.Shared.Utils;
using Core.BaseService.EF;
using Microsoft.IdentityModel.Tokens;
using RCMServerData.EFContext;
using RCMServerData.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlazorRCM.Server.Services.Business.EF
{
    public class EfUserRepo : EfRepositoryBase<RCMBlazorContext, User, UserDTO>, IUserRepo
        
    {
        private IConfiguration configuration;
        private IMapper mapper;
        

        public EfUserRepo(IMapper Mapper, IConfiguration Configuration) : base(Mapper, Configuration)
        {
            configuration = Configuration;
            mapper = Mapper;
        }

        public async Task<UserLoginResponseDTO> Login(string Username, string Password)
        {

            //using(RCMBlazorContext ctx = new())
            //{
            //    ctx.Set<User>
            //}
            // Veritabanı Kullanıcı Doğrulama İşlemleri Yapıldı.
            UserDTO dbUser = new ();
            var encryptedPassword = PasswordEncrypter.Encrypt(Password);
            try
            {
                dbUser = await base.Get(i => i.UserName == Username && i.Password == encryptedPassword);
            }
            catch (Exception)
            {
                throw;
            }
            //var dbUser = await context.Users.FirstOrDefaultAsync(i => i.EMailAddress == EMail && i.Password == Password);

            if (dbUser == null)
                throw new Exception("User not found or given information is wrong");

            var User= mapper.Map<User>(dbUser);

            if (!User.IsActive)
                throw new Exception("User state is Passive!");

            UserLoginResponseDTO result = new();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(int.Parse(configuration["JwtExpiryInDays"].ToString()));

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, dbUser.FullName),
                new Claim(ClaimTypes.Email, dbUser.Email!)
                //new Claim(ClaimTypes.Name, dbUser.FirstName + " " + dbUser.LastName),
                //new Claim(ClaimTypes.UserData, dbUser.Id.ToString())
            };

            var token = new JwtSecurityToken(configuration["JwtIssuer"], configuration["JwtAudience"], claims, null, expiry, creds);

            result.ApiToken = new JwtSecurityTokenHandler().WriteToken(token);
            result.User = dbUser;


            return result;
        }




        //public async Task<UserLoginResponseDTO> Login(string EMail, string Password)
        //{
        //    // Veritabanı Kullanıcı Doğrulama İşlemleri Yapıldı.

        //    var encryptedPassword = PasswordEncrypter.Encrypt(Password);

        //    var dbUser = await context.Users.FirstOrDefaultAsync(i => i.EMailAddress == EMail && i.Password == encryptedPassword);

        //    //var dbUser = await context.Users.FirstOrDefaultAsync(i => i.EMailAddress == EMail && i.Password == Password);

        //    if (dbUser == null)
        //        throw new Exception("User not found or given information is wrong");

        //    if (!dbUser.IsActive)
        //        throw new Exception("User state is Passive!");


        //    UserLoginResponseDTO result = new UserLoginResponseDTO();

        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSecurityKey"]));
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        //    var expiry = DateTime.Now.AddDays(int.Parse(configuration["JwtExpiryInDays"].ToString()));

        //    var claims = new[]
        //    {
        //        new Claim(ClaimTypes.Email, EMail),
        //        new Claim(ClaimTypes.Name, dbUser.FirstName + " " + dbUser.LastName),
        //        new Claim(ClaimTypes.UserData, dbUser.Id.ToString())
        //    };

        //    var token = new JwtSecurityToken(configuration["JwtIssuer"], configuration["JwtAudience"], claims, null, expiry, creds);

        //    result.ApiToken = new JwtSecurityTokenHandler().WriteToken(token);
        //    result.User = mapper.Map<UserDTO>(dbUser);

        //    return result;
        //}






        //public List<User> GetByAuthorityTypeId(byte ATId)
        //{
        //    return
        //        base.GetAll(x => x.UserBranchAuthorities
        //            .Select(y => y.ATId)
        //            .Contains(ATId))
        //            .ToList();
        //}
    }
}
