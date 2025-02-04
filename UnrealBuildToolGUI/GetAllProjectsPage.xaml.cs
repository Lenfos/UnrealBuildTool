using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Logic;
using Microsoft.WindowsAPICodePack.Dialogs;


namespace UnrealBuildTool;

public partial class GetAllProjectsPage : Window
{
    public GetAllProjectsPage()
    {
        InitializeComponent();
    }

    private void DirectoryButton_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        var dialog = new CommonOpenFileDialog
        {
            IsFolderPicker = true,
            Title = "Select Directory",
        };

        if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
        {
            string directory = dialog.FileName;
            DirectoryButton.Text = directory;
        }
    }

    private void SearchButton_OnClick(object sender, RoutedEventArgs e)
    {
        string path = DirectoryButton.Text;
        if (!path.EndsWith(@"\"))
        {
            path += @"\";
        }
        Console.WriteLine(path);
        ProjectListBox.Items.Clear();
        List<Projects> projects = SearchProject.GetAllProjects(path);
        
        ProjectsListItemInit(projects);
    }

    private void ProjectsListItemInit(List<Projects> projects)
    {
        if (projects.Count == 0)
        {
            ListBoxItem item = new ListBoxItem();
            item.Content = "No Projects Found";
            ProjectListBox.Items.Add(item);
        }
        foreach (Projects iProj in projects)
        {
            ListBoxItem items = new ListBoxItem();
            items.Content = iProj.Name;
            items.MouseDoubleClick += (sender, e) => ProjectItem_Click(sender, e, iProj);
            
            ProjectListBox.Items.Add(items);
        }
    }

    private void ProjectItem_Click(object sender, RoutedEventArgs e, Projects project)
    {
        ShowInfoPage showInfo = new ShowInfoPage(WindowEnum.GetAllWindows, project);
        showInfo.Show();
        this.Close();
    }

    private void BackButton_OnClick(object sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        this.Close();
    }
}