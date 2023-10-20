using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace NoteBloc.Commands.Fichier
{
    internal class NewWindowCommand : ICommand
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
            // Ouvrir une nouvelle fenêtre
            MainWindow newWindow = new MainWindow();
            newWindow.Show();
        }
    }
}
