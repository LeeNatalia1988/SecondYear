using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using UserWorker.Abstractions;
using UserWorker.AuthorizationModels;
using UserWorker.DbModels;
using UserWorker.DTO;

namespace UserWorker.Controllers
{
    public static class RsaTools
    {
        public static RSA GetPrivateKey()
        {
            var f = File.ReadAllText("rsa/private_key.pem");

            var rsa = RSA.Create();
            rsa.ImportFromPem(f);
            return rsa;
        }
    }

    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        //private readonly IUserAuthenticationService _userAuthServ;
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public LoginController(IConfiguration config, IUserRepository repository, IMapper mapper)
        {
            _config = config;
            _repository = repository;
            _mapper = mapper;
        }

        private static UserRole RoleIDToRole(RoleId roleId)
        {
            if (roleId == RoleId.Admin) return UserRole.Admin;
            else return UserRole.User;
        }

        [AllowAnonymous]
        [HttpPost(template: "Получить token")]
        public ActionResult Login([FromQuery] UserViewModel userViewModel)
        {
            /*var user = _userAuthServ.Authenticate(userLogin);
            if(user != null)
            {
                var token = GenerateToken(user);
                return Ok(token);
            }
            return NotFound("Пользователь не найден. Пожалуйста, зарегистрируйтесь.");*/
            try
            {
                var roleId = _repository.UserCheck(userViewModel);
                var user = new UserModel { Email = userViewModel.Email, Role = RoleIDToRole(roleId) };
                var token = GenerateToken(user);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        private string GenerateToken(UserModel user)
        {
            //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtConfiguration:Key"]));
            var key = new RsaSecurityKey(RsaTools.GetPrivateKey());
            var credentials = new SigningCredentials(key, SecurityAlgorithms.RsaSha256Signature);
            var claim = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var token = new JwtSecurityToken(_config["JwtConfiguration:Issuer"],
                _config["JwtConfiguration:Audience"],
                claim,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
