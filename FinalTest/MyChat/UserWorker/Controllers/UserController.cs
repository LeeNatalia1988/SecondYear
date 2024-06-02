using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using UserWorker.Abstractions;
using UserWorker.AuthorizationModels;
using UserWorker.Db;
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
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserController(IConfiguration config, IUserRepository repository, IMapper mapper)
        {
            _config = config;
            _repository = repository;
            _mapper = mapper;
        }

        public static UserRole RoleIDToRole(RoleId roleId)
        {
            if (roleId == RoleId.Admin) return UserRole.Admin;
            else return UserRole.User;
        }

        [AllowAnonymous]
        [HttpPost(template: "Get_token")]
        public ActionResult Login([FromQuery] UserViewModel userViewModel)
        {
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
            using (var context = new UserContext())
            {
                var userGuid = context.Users.FirstOrDefault(x => x.Email == user.Email).Id.ToString();
                var key = new RsaSecurityKey(RsaTools.GetPrivateKey());
                var credentials = new SigningCredentials(key, SecurityAlgorithms.RsaSha256Signature);
                var claim = new[]
                {
                new Claim(ClaimTypes.NameIdentifier, userGuid),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                };
                var token = new JwtSecurityToken(_config["JwtConfiguration:Issuer"],
                    _config["JwtConfiguration:Audience"],
                    claim,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials);


                return new JwtSecurityTokenHandler().WriteToken(token);
            }
        }


        //ok
        [AllowAnonymous]
        [HttpPost(template: "Add_admin")]
        public ActionResult AddAdmin([FromQuery] UserViewModel userViewModel)
        {
            try
            {
                _repository.AddAdmin(userViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return Ok();
        }
        //ok
        [AllowAnonymous]
        [HttpPost(template: "Add_user")]
        public ActionResult AddUser([FromQuery] UserViewModel userViewModel)
        {
            try
            {
                _repository.AddUser(userViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return Ok();
        }
        //ok
        [HttpPost(template: "Delete_user")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteUser([FromQuery] string email)
        {
            try
            {
                GetCurrentUser();
                _repository.DeleteUser(email);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok();
        }
        //ok
        [AllowAnonymous]
        [HttpGet(template: "Get_users")]
        public ActionResult<IEnumerable<UserViewModelWithoutPassword>> GetUsers()
        {
            try
            {
                return Ok(_repository.GetUsers());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        //ok
        [AllowAnonymous]
        [HttpGet(template: "Get_userID")]
        public ActionResult<Guid> GetUserID([FromQuery] string email)
        {
            try
            {
                GetCurrentUser();
                return Ok(_repository.GetUserID(email));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        private UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                return new UserModel
                {
                    Id = userClaims.FirstOrDefault(e => e.Type == ClaimTypes.NameIdentifier)?.Value,
                    Role = (UserRole)Enum.Parse(typeof(UserRole), userClaims.FirstOrDefault(r => r.Type == ClaimTypes.Role)?.Value)
                };
            }
            return null;
        }
    }
}
