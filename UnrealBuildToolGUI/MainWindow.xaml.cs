using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UnrealBuildTool;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ShowInfoButton_OnClick(object sender, RoutedEventArgs e)
    {
        ShowInfoPage showInfoPage = new ShowInfoPage(WindowEnum.MainWindow);
        showInfoPage.Show();
        this.Close();
    }

    private void BuildButton_OnClick(object sender, RoutedEventArgs e)
    {
        UBTPage ubtPage = new UBTPage();
        ubtPage.Show();
        this.Close();
    }

    private void GetAllButton_OnClick(object sender, RoutedEventArgs e)
    {
        GetAllProjectsPage getAllProjectsPage = new GetAllProjectsPage();
        getAllProjectsPage.Show();
        this.Close();
    }

    private void PackageButton_OnClick(object sender, RoutedEventArgs e)
    {
        UATPage uatPage = new UATPage();
        uatPage.Show();
        this.Close();
    }
}