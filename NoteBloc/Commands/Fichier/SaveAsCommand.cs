 using NoteBloc.Models;
using NoteBloc.ViewModels;
using System.Windows.Input;
using System;
using NoteBloc.Services;

namespace NoteBloc.Commands
{
    internal class SaveAsCommand : ICommand
    {
        private readonly MainViewModel _viewModel;
        private readonly INoteService _service;

        public SaveAsCommand(MainViewModel viewModel, INoteService service)
        {
            _viewModel = viewModel;
            _service = service;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


        public bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_viewModel.CurrentNoteContent);
        }

        public void Execute(object parameter)
        {
            var note = new Note
            {
                Id = Guid.NewGuid().ToString(),
                Name = _viewModel.CurrentNoteName,
                Content = _viewModel.CurrentNoteContent,
                LastModified = DateTime.Now
            };

            string chosenFilePath = ShowSaveFileDialog();
            if (!string.IsNullOrEmpty(chosenFilePath))
            {
                note.FilePath = chosenFilePath;
                _service.Save(note);
            }
        }


        private string ShowSaveFileDialog()
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.DefaultExt = "Sans titre.txt";
            dlg.Filter = "Text documents (.txt)|*.txt";
            bool? result = dlg.ShowDialog();
            if (result == true)
            {
                return dlg.FileName;
            }
            return null;
        }
    }
}
