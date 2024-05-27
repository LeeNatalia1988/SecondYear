using Microsoft.AspNetCore.Mvc;
using Notes.Abstractions;
using Notes.DTO;

namespace Notes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly INoteRepository _repository;
        public NoteController(INoteRepository repository)
        {
            _repository = repository;
        }

        [HttpPost(template: "add_note")]
        public ActionResult AddNote(NoteViewModel noteViewModel)
        {
            try
            {
                _repository.AddNote(noteViewModel);
                return Ok();
            }
            catch
            {
                return StatusCode(409);
            }
        }

        [HttpGet(template: "get_notes")]
        public ActionResult<IEnumerable<NoteViewModel>> GetNotes()
        {
            return Ok(_repository.GetNotes());
        }

        [HttpPost(template: "delete_note")]
        public ActionResult DeleteNote(string title)
        {
            _repository.DeleteNote(title);
            return Ok();
        }

        [HttpPost(template: "change_note_description")]
        public ActionResult ChangeNoteDescription(string title, string description)
        {
            _repository.ChangeNoteDescription(title, description);
            return Ok();
        }
    }
}
