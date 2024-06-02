using MessageWorker.Abstractions;
using MessageWorker.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace MessageWorker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageRepository _repository;

        public MessageController(IMessageRepository messageRepository)
        {
            _repository = messageRepository;
        }

        
        [HttpPost(template: "Отправить сообщение")]
        public ActionResult SendMessage([FromQuery] MessageViewModelToSend messageViewModel)
        {
            string fromUser = GetGuid();
            if (fromUser == null)
            {
                return StatusCode(500, "Сначала пройдите авторизацию.");
            }
            try
            {
                _repository.SendMessage(messageViewModel, fromUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return Ok();
        }

        [HttpGet(template: "Получить сообщения")]

        public ActionResult<List<string>> ReceiveMessages()
        {
            string userName = GetGuid();
            try
            {
                return Ok(_repository.ReceiveMessage(userName));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return Ok();
        }

        private string GetGuid()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                return userClaims.FirstOrDefault(e => e.Type == ClaimTypes.NameIdentifier)?.Value;
            }
            return null;
        }
    }
}
