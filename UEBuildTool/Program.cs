using Logic;

namespace UEBuildTool;

static class MainClass
{
    public static void Main(string[] args)
    {
        Projects projs =  SearchProject.GetProjects(@"C:\UnrealEngine-5.5\TestProject\TestProject.uproject");
        string path = @"C:\UnrealEngine-5.5\Engine\Build\BatchFiles\Build.bat";

        string projectPath =
            @"C:\UnrealEngine-5.5\TestProject\TestProject.uproject";

        SearchProject.GetProjectsName(projectPath);
    }
}