using System;
using System.Windows;
using System.Windows.Input;

namespace NoteBloc.Commands.Fichier
{
    internal class CloseAllWindowsCommand : ICommand
    {
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
            // Fermer toute les fenêtres
            Application.Current.Shutdown();
        }
    }
}
