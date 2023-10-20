using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NoteBloc.Commands.General
{
    internal class MaximizeWindowCommand : ICommand
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
                if (window.WindowState == WindowState.Maximized)
                    window.WindowState = WindowState.Normal;
                else window.WindowState = WindowState.Maximized;
            }
        }

    }
}
