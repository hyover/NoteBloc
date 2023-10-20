using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBloc.Services
{
    internal class NoteService : INoteService
    {
        // Méthode pour vérifier si une note a des modifications non enregistrées
        public bool NoteHasUnsavedChanges(string content)
        {
            return !string.IsNullOrEmpty(content);
        }

        // ... d'autres méthodes liées à la gestion des notes ...
    }
}
