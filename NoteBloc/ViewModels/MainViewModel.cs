using NoteBloc.Commands.Fichier;
using NoteBloc.Commands.General;
using NoteBloc.Services;
using System.Windows.Input;

namespace NoteBloc.ViewModels
{
    public class MainViewModel
    {
        public ICommand MinimizeWindowCommand { get; }
        public ICommand MaximizeWindowCommand { get; }
        public ICommand DragWindowCommand { get; }
        public ICommand CloseWindowCommand { get; }
        public ICommand CloseAllWindowsCommand { get; }
        public ICommand NewWindowCommand { get; }

        private readonly INoteService _noteService;
        public string CurrentNoteName { get; set; }
        public string CurrentNoteContent { get; set; }



        public MainViewModel(INoteService noteService)
        {
            MinimizeWindowCommand = new MinimizeWindowCommand();
            MaximizeWindowCommand = new MaximizeWindowCommand();
            DragWindowCommand = new DragWindowCommand();
            CloseWindowCommand = new CloseWindowCommand(_noteService);
            CloseAllWindowsCommand = new CloseAllWindowsCommand();
            NewWindowCommand = new NewWindowCommand();
            _noteService = noteService;
        }

        public MainViewModel()
        {
        }


        // Utilisez le service pour vérifier si des modifications ont été apportées
        public bool NoteHasUnsavedChanges(string content)
        {
            return _noteService.NoteHasUnsavedChanges(content);
        }
    }
}
