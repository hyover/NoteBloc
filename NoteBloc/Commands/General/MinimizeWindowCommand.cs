using System;
using System.Windows;
using System.Windows.Input;
using NoteBloc.Commands;

namespace NoteBloc.Commands.General
{
    internal class MinimizeWindowCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true; // Dans ce cas, on peut toujours minimiser la fenêtre
        }

        public void Execute(object parameter)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
    }
}
