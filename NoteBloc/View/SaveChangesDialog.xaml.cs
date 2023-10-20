using System.Windows;

namespace NoteBloc.View;
public partial class SaveChangesDialog : Window
{
    public SaveChangesDialog(string noteName)
    {
        InitializeComponent();
        txtMessage.Text = $"Voulez-vous enregistrer les modifications apportées à {noteName}?";
    }

}

