using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace NoteBloc
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Top window
        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void BtnMinimize_Click(object sender,  RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void BtnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if(WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else WindowState = WindowState.Maximized;
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        // Menu
        private void NewMenuItem_Click(object sender, RoutedEventArgs e)
        {
            CurrentTextBox.Clear();
        }

        private void OpenMenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                CurrentTextBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void SaveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Sans titre.txt";

            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, CurrentTextBox.Text);
            }
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            CurrentTextBox.Cut();
        }

        private void CopyMenuItem_Click(object sender, RoutedEventArgs e)
        {
            CurrentTextBox.Copy();
        }

        private void PasteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            CurrentTextBox.Paste();
        }

        private void NewTabMenuItem_Click(object sender, RoutedEventArgs e)
        {
            TabItem newTab = new TabItem
            {
                Header = "Sans titre",
                Content = new TextBox
                {
                    AcceptsReturn = true,
                    AcceptsTab = true,
                    VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                    HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
                    TextWrapping = TextWrapping.Wrap
                }
            };

            tabControlNotes.Items.Add(newTab);
            tabControlNotes.SelectedItem = newTab;
        }

        private void CloseTabMenuItem_Click(object sender, RoutedEventArgs e)
        {
            TabItem currentTab = tabControlNotes.SelectedItem as TabItem;
            if (NoteHasUnsavedChanges(currentTab))
            {
                SaveChangesDialog dialog = new SaveChangesDialog(currentTab.Header.ToString());
                dialog.ShowDialog();

                switch (dialog.Result)
                {
                    case CustomDialogResult.Save:
                        // Enregistrez la note ici.
                        break;
                    case CustomDialogResult.DontSave:
                        tabControlNotes.Items.Remove(currentTab);
                        if (tabControlNotes.Items.Count == 0)
                            this.Close();  // ferme la fenêtre si c'est le dernier onglet
                        break;
                    case CustomDialogResult.Cancel:
                        // Ne faites rien.
                        break;
                }
            }
            else
            {
                tabControlNotes.Items.Remove(currentTab);
                if (tabControlNotes.Items.Count == 0)
                    this.Close();  // ferme la fenêtre si c'est le dernier onglet
            }
        }

        private bool NoteHasUnsavedChanges(TabItem tabItem)
        {
            // Cette méthode vérifie si la note a des modifications non enregistrées.
            // Pour l'instant, c'est une simple vérification pour voir si le contenu est vide. 
            // Vous pouvez améliorer cette vérification en fonction de vos besoins.
            var textBox = tabItem.Content as TextBox;
            return !string.IsNullOrEmpty(textBox?.Text);
        }

        private TextBox CurrentTextBox => ((tabControlNotes.SelectedItem as TabItem)?.Content as TextBox);

        private void tabControlNotes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtEditor1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
