using AutoMapper;
using GB_Market.DB;
using Microsoft.Extensions.Caching.Memory;
using Notes.Abstractions;
using Notes.DTO;
using Notes.Models;
using System.Xml.Linq;

namespace Notes.Repository
{
    public class NoteRepository : INoteRepository
    {
        private readonly IMapper _mapper;
        private IMemoryCache _memoryCache;
        public NoteRepository(IMapper mapper, IMemoryCache memoryCache)
        {
            _mapper = mapper;
            _memoryCache = memoryCache;
        }
        public int AddNote(NoteViewModel noteViewModel)
        {
            using (var context = new NotesContext())
            {
                var entity = _mapper.Map<Note>(noteViewModel);
                entity.CreatedDate = DateTime.Now.ToString("dd MMMM yyyy");
                context.Notes.Add(entity);
                context.SaveChanges();
                _memoryCache.Remove("notes");
                return 1;
            }
        }

        public int ChangeNoteDescription(string title, string description)
        {
            using (var ctx = new NotesContext())
            {
                if (ctx.Notes.FirstOrDefault(x => x.Title.ToLower() == title.ToLower()) != null)
                {
                    var note = ctx.Notes.Where(x => x.Title.ToLower() == title.ToLower()).FirstOrDefault();
                    note.Description = description;
                    ctx.SaveChanges();
                    _memoryCache.Remove("notes");
                    return 1;
                }
                else
                {
                    throw new Exception("Note not exist");
                }
            }
        }

        public int DeleteNote(string title)
        {
            using (var context = new NotesContext())
            {
                var entity = context.Notes.FirstOrDefault(x => x.Title.Equals(title));
                if (entity != null)
                {
                    context.Notes.Remove(entity);
                    context.SaveChanges();
                    _memoryCache.Remove("notes");
                    return 1;
                }
                else
                {
                    throw new Exception("Note not exist");
                }
            }
        }

        public IEnumerable<NoteViewModel> GetNotes()
        {
            if (_memoryCache.TryGetValue("notes", out List<NoteViewModel> noteCache))
            {
                return noteCache;
            }
            using (var context = new NotesContext())
            {
                var notes = context.Notes.Select(_mapper.Map<NoteViewModel>).ToList();
                _memoryCache.Set("notes", notes, TimeSpan.FromMinutes(30));
                return notes;
            }
        }
    }
}
