using System;
using System.Windows.Input;
using System.Windows;
using NoteBloc.Services;
using NoteBloc.ViewModels;

namespace NoteBloc.Commands.General
{
    internal class CloseWindowCommand : ICommand
    {
        private readonly INoteService _noteService;

        public CloseWindowCommand(INoteService noteService)
        {
            _noteService = noteService;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true; // Toujours exécutable
        }

        public void Execute(object parameter)
        {
            var window = parameter as Window;
            if (window != null)
            {
                var mainViewModel = window.DataContext as MainViewModel;

                // Utilisation des nouvelles propriétés pour vérifier les modifications non enregistrées et afficher le dialogue
                if (mainViewModel != null && _noteService.NoteHasUnsavedChanges(mainViewModel.CurrentNoteContent))
                {
                    // Passez le nom de la note au constructeur de SaveChangesDialog
                    var saveChangesDialog = new SaveChangesDialog(mainViewModel.CurrentNoteName);
                    saveChangesDialog.ShowDialog();

                    // TODO: Ajoutez la logique pour gérer le choix de l'utilisateur
                }
                else
                {
                    window.Close();
                }
            }
        }


    }
}
