using Logic;

namespace UEBuildTool;

static class MainClass
{
    public static void Main(string[] args)
    {
        string path = "";
        if (args.Length == 0)
        {
            path = "-h";
        }
        else
        {
            path = args[0];
        }
        
        if (path == "-h")
        {
            Console.WriteLine(
                "Don't forget the path to your project as a first argument for the 3 first options. There is 4 options available : \n 1. show-infos : show project detail from .uproject \n 2. build : Build uproject with UBT \n 3. package : Package the project with UAT. Warning : Need to have a third argument with the target path \n 4. all-projects : Show all the projects found in the disk. 3rd argument is optional : Path from where to start searching (default : c:/ ");
                return;
        }
        else if (path == "all-projects")
        {
            if (args.Length == 2)
            {
                string target = args[1];
                SearchProject.GetAllProjects(target);
                return;
            }
            SearchProject.GetAllProjects();
            return;
        }

        switch (args[1])
        {
            case "show-infos" : SearchProject.GetProjects(path); break;
            case "build" : Build.UBT(path); break;
            case "package":
            {
                string target = args[2];
                Build.UAT(path, target);
            } ; break;
            default: Console.WriteLine("Unknown Options try -h for help"); break;
        }
    }
}