// Commands/General/DragWindowCommand.cs

using System;
using System.Windows;
using System.Windows.Input;

namespace NoteBloc.Commands.General
{
    internal class DragWindowCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true; // Toujours exécutable
        }

        public void Execute(object parameter)
        {
            var window = parameter as Window;
            if (window != null)
            {
                try
                {
                    window.DragMove();
                }
                catch (InvalidOperationException)
                {
                    // Cette exception peut se produire si la fenêtre n'est pas actuellement en état de recevoir des événements mouse down. 
                    // C'est juste pour s'assurer que l'application ne plante pas dans ces cas.
                }
            }
        }
    }
}
