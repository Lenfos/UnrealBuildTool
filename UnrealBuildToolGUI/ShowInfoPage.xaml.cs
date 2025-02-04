using System.Windows;
using System.Windows.Controls;
using Logic;
using Microsoft.Win32;

namespace UnrealBuildTool;

public partial class ShowInfoPage : Window
{
    private Projects? proj;
    private WindowEnum prevPage;
    public ShowInfoPage(WindowEnum previousPage, Projects? project = null)
    {
        InitializeComponent();
        proj = project;
        prevPage = previousPage;
        
        Initialize();
    }

    private void Initialize()
    {
        if (proj != null)
        {
            FileButtonTextBlock.Visibility = Visibility.Hidden;
            ChooseFileButton.Visibility = Visibility.Hidden;
            
            FillBoxInfo(proj.Path);
        }
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
            FillBoxInfo(openFileDialog.FileName);
        }
    }

    private void FillBoxInfo(string path)
    {
        PathBox.Text = path;
        Projects proj = SearchProject.GetProjects(path);
         
        ProjectNameBox.Text = proj.Name;
        UnrealVersionBox.Text = proj.UnrealVersion;
        foreach (string iPlugins in proj.Plugins)
        {
            ListBoxItem items = new ListBoxItem();
            items.Content = iPlugins;
            
            PluginsBox.Items.Add(items);
        }
    }

    private void BackButton_OnClick(object sender, RoutedEventArgs e)
    {
        Window newWindow;
        switch (prevPage)
        {
            case WindowEnum.MainWindow : newWindow = new MainWindow(); break;
            case WindowEnum.GetAllWindows : newWindow = new GetAllProjectsPage(); break;
            default: newWindow = new MainWindow(); break;
        }
        
        newWindow.Show();
        this.Close();
    }
}