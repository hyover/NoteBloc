using System;
using System.Windows;
using System.Windows.Controls;
using NoteBloc.ViewModels;

namespace NoteBloc.View
{
    public partial class MainWindow : Window

    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void NoteTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var viewModel = DataContext as MainViewModel;
            viewModel.CurrentNoteContent = (sender as TextBox).Text;
            // Mettez à jour CurrentNoteName si nécessaire, par exemple si vous avez une TextBox pour le titre de la note.
        }

    }
}
