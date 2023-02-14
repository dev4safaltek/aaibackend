using AAI.Common;
using AAI.DataContract.Enums;
using AAI.DataContract.Models;
using AAI.DataContract.Models.Entity;
using AAI.DataContract.Models.Entity.DB;
using AAI.ServiceContract.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AAI.Service.Login
{
    public class LoginService : ILoginService
    {
        //private readonly ILoginRepository _loginRepository;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _accessor;
        private readonly JwtSettingModel _jwtSetting;
        private readonly EntityDbContext _dbcontext;

        public LoginService(
            IHttpContextAccessor accessor,
            IConfiguration configuration,
            IOptions<JwtSettingModel> jwtoption,
            EntityDbContext dbcontext)
        {
            _jwtSetting = jwtoption.Value;
            _configuration = configuration;
            _accessor = accessor;
            _dbcontext = dbcontext;
        }

        /// <summary>
        /// Function used to check user Credentials in DB
        /// </summary>
        public async Task<APIResponse> LoginAsync(string username, string password)
        {

            UserDetailModel sessionModel = null;
            string hashPassword = PasswordSHA512CryptoProvider.CreateHash(password);
            Users loginDetails = new Users();
            loginDetails = await _dbcontext.Users.FirstOrDefaultAsync(a => a.Email == username && a.Password == password);
            // var loginDetails =
            //    await _dbcontext.Users.FirstOrDefaultAsync(a => a.Email == username );

            if (loginDetails != null)
            {
                sessionModel = new UserDetailModel() { UserID = loginDetails.UserId, UserName = loginDetails.Email, FullUserName = loginDetails.FirstName + ' ' + loginDetails.LastName, UserIP = string.Empty };
                APIResponse response = new APIResponse(StatusCodesEnum.LoginSucess, sessionModel);
                if (response.StatusCode == StatusCodesEnum.LoginSucess)
                {
                    var authClaims = new List<Claim>
                    {
                       new Claim(ClaimTypes.Name, loginDetails.Email),
                       new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };
                    response.Result = loginDetails;
                    //response.Result = GenerateToken(response.Result as UserDetailModel);
                }
                return response;
            }
            else
            {
                return new APIResponse(StatusCodesEnum.InvalidUserIDPassword, sessionModel);
            }
        }

        /// <summary>
        /// Function used to generate token key
        /// </summary>
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTSettings:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWTSettings:Authority"],
                audience: _configuration["JWTSettings:Audience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return token;
        }


    }
}
