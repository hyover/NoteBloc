using NoteBloc.Models;
using System;
using System.IO;

namespace NoteBloc.Services;
public class FileNoteService : INoteService
{
    public void Save(Note note)
    {
        if (string.IsNullOrEmpty(note.FilePath))
        {
            note.FilePath = "Sans titre.txt"; // Un chemin par défaut, à changer selon vos besoins.
        }

        System.IO.File.WriteAllText(note.FilePath, note.Content);
        note.LastModified = DateTime.Now;
    }


}