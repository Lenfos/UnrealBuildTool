using Logic;

namespace UEBuildTool;

static class MainClass
{
    public static void Main(string[] args)
    {
        Projects projs =  SearchProject.GetProjects(@"C:\Users\pierr\OneDrive\Documents\Unreal Projects\travailleconnard\travailleconnard.uproject");

        Console.WriteLine(projs);
    }
}