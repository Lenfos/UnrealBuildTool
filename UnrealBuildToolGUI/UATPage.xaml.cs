using System.Windows;
using Logic;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace UnrealBuildTool;

public partial class UATPage : Window
{
    public UATPage()
    {
        InitializeComponent();
    }

    private void BackButton_OnClick(object sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
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
            UEFolderTextBox.Text = directory;
        }
    }

    private void PackageButton_OnClick(object sender, RoutedEventArgs e)
    {
        Build.GUI_UAT(UprojectTextBox.Text, TargetFolderTextBox.Text, UEFolderTextBox.Text);
    }

    private void BrowseTargetFolder_OnClick(object sender, RoutedEventArgs e)
    {
        var dialog = new CommonOpenFileDialog
        {
            IsFolderPicker = true,
            Title = "Select Directory",
        };

        if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
        {
            string directory = dialog.FileName;
            TargetFolderTextBox.Text = directory;
        }
    }
}