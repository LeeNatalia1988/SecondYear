using Notes.DTO;

namespace Notes.Abstractions
{
    public interface INoteRepository
    {
        public int AddNote(NoteViewModel noteViewModel);
        public IEnumerable<NoteViewModel> GetNotes();

        public int DeleteNote(string title);

        public int ChangeNoteDescription(string title, string description);
    }
}
