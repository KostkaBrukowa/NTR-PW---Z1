using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Z01.Models
{
    public class NoteViewModel
    {
        public NoteViewModel(Note note)
        {
            NoteId = note.NoteID;
            RowVersion = note.RowVersion;
            CreationDate = note.NoteDate;
            Title = note.Title;
            Description = note.Description;
            Markdown = note.Markdown;
            Categories = new HashSet<Category>();

            if (note.NoteCategories == null) return;
            
            foreach (var noteCategory in note.NoteCategories.Where(noteCategory => noteCategory.NoteID == note.NoteID))
            {
                Categories.Add(noteCategory.Category);
            }
        }

        public int NoteId { get; set; }
        public byte[] RowVersion { get; set; }
        public DateTime CreationDate { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        public bool Markdown { get; set; }

        [Required]
        [StringLength(1060, MinimumLength = 3)]
        public string Description { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
