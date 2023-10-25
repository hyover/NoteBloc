using NoteBloc.Models;


namespace NoteBloc.Services;

public interface INoteService
{
    void Save(Note note);
    // D'autres méthodes pour charger, etc. peuvent être ajoutées plus tard
}