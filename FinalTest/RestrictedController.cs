using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UserWorker.AuthorizationModels;
using UserWorker.DTO;

namespace UserWorker.Controllers
{
    /*[ApiController]
    [Route("[controller]")]
    public class RestrictedController : ControllerBase
    {
        [HttpGet]
        [Route("Подтвердить (Admin)")]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminEndPoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Привет, {currentUser.Role}!");
        }

        [HttpGet]
        [Route("Подтвердить (Users)")]
        [Authorize(Roles = "Admin, User")]
        public IActionResult UserEndPoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Привет, {currentUser.Role}!");
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
    }*/
}

