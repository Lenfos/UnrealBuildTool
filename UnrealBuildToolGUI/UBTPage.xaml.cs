using System.Windows;
using Logic;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace UnrealBuildTool;

public partial class UBTPage : Window
{
    public UBTPage()
    {
        InitializeComponent();
    }

    private void BackButton_OnClick(object sender, RoutedEventArgs e)
    {
        MainWindow window = new MainWindow();
        window.Show();
        this.Close();
    }

    private void ChooseFileButton_OnClick(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog
        {
            Title = "Select a .uproject file",
            Filter = "Unreal Project Files (*.uproject)|*.uproject|All Files (*.*)|*.*"
        };

        if (openFileDialog.ShowDialog() == true)
        {
            UprojectTextBox.Text = openFileDialog.FileName;
        }
    }

    private void BrowseUeFolder_OnClick(object sender, RoutedEventArgs e)
    {
        var dialog = new CommonOpenFileDialog
        {
            IsFolderPicker = true,
            Title = "Select Directory",
        };

        if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
        {
            string directory = dialog.FileName;
            FolderTextBox.Text = directory;
        }
    }


    private void BuildButton_OnClick(object sender, RoutedEventArgs e)
    {
        Build.GUI_UBT(UprojectTextBox.Text, FolderTextBox.Text);
    }
}