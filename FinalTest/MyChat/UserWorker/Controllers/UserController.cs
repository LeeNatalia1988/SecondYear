using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserWorker.Abstractions;
using UserWorker.DbModels;
using UserWorker.DTO;

namespace UserWorker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository userRepository) 
        {
            this._repository = userRepository;
        } 
        //ok
        [AllowAnonymous]
        [HttpPost(template: "Добавить админа (доступ для всех)")]
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
        [HttpPost(template: "Добавить пользователя (доступ для всех)")]
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

        [HttpDelete(template: "Удалить пользователя (доступ только для администратора)")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteUser([FromQuery] string email)
        {
            try
            {
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
        [HttpGet(template: "Посмотреть список пользователей (доступ для всех)")]
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
        [HttpGet(template: "Посмотреть ID пользователя (доступ для всех)")]
        public ActionResult<Guid> GetUserID([FromQuery] string email)
        {
            try
            {
                return Ok(_repository.GetUserID(email));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}
