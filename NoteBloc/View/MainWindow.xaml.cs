using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using NoteBloc.ViewModels;

namespace NoteBloc
{
    public partial class MainWindow : Window

    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

      

        

       
    }
}
