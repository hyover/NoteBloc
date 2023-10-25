using System;
using System.Windows;
using System.Windows.Input;
using NoteBloc.Services;

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
           if(window != null)
           {
               
           }
           else
           {
                window.Close();
           }
        }


    }
}
