using System.Windows;

namespace NoteBloc;
public partial class SaveChangesDialog : Window
{
    public CustomDialogResult Result { get; private set; }

    public SaveChangesDialog(string noteName)
    {
        InitializeComponent();
        txtMessage.Text = $"Voulez-vous enregistrer les modifications de {noteName}?";
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        Result = CustomDialogResult.Save;
        this.Close();
    }

    private void DontSaveButton_Click(object sender, RoutedEventArgs e)
    {
        Result = CustomDialogResult.DontSave;
        this.Close();
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        Result = CustomDialogResult.Cancel;
        this.Close();
    }
}

public enum CustomDialogResult
{
    Save,
    DontSave,
    Cancel
}


