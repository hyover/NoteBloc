using NoteBloc.Commands;
using NoteBloc.Commands.Fichier;
using NoteBloc.Commands.General;
using NoteBloc.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace NoteBloc.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _currentNoteContent;
        private readonly INoteService _noteService;


        // Implémentation de INotifyPropertyChanged ici

        public ICommand MinimizeWindowCommand { get; }
        public ICommand MaximizeWindowCommand { get; }
        public ICommand CloseWindowCommand { get; }
        public ICommand CloseAllWindowsCommand { get; }
        public ICommand NewWindowCommand { get; }
        public ICommand SaveAsCommand { get; }
        public string CurrentNoteName { get; set; }

        public string CurrentNoteContent
        {
            get { return _currentNoteContent; }
            set
            {
                if (value != _currentNoteContent)
                {
                    _currentNoteContent = value;
                    OnPropertyChanged(nameof(CurrentNoteContent));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public MainViewModel(INoteService noteService)
        {
            _noteService = noteService;
            MinimizeWindowCommand = new MinimizeWindowCommand();
            MaximizeWindowCommand = new MaximizeWindowCommand();
            CloseWindowCommand = new CloseWindowCommand(_noteService);
            CloseAllWindowsCommand = new CloseAllWindowsCommand();
            NewWindowCommand = new NewWindowCommand();
            SaveAsCommand = new SaveAsCommand(this, _noteService);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
