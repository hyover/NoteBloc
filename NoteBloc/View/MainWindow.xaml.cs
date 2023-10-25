using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using NoteBloc.Services;
using NoteBloc.ViewModels;

namespace NoteBloc.View
{
    public partial class MainWindow : Window

    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(new FileNoteService());
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

    }
}
