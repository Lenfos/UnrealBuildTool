using System.Diagnostics;

namespace Logic;

public class Build
{

    private static string target = "TestProject";
    private static string plateform = "Win64";
    private static string state = "Development";
    
    public static void UBT(string projectpath)
    {
        target = SearchProject.GetProjectsName(projectpath);
        
        string command  = @$"C:\UnrealEngine-5.5\Engine\Build\BatchFiles\Build.bat {target} {plateform} {state} -Project=" + $"\"{projectpath}\""+
        " -Progress -NoHotReload";
        string url = @"C:\Users\pierr\OneDrive\Documents\Unreal Projects\travailleconnard\";
        Console.WriteLine(command);
        
        
        /*Process.Start("cmd.exe", $"/c cd {url}");
        Process.Start("cmd.exe", $"/c {command}");*/
        
        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = $"/c {command}",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        Process process = new Process { StartInfo = psi };
        process.Start();

        string output = process.StandardOutput.ReadToEnd();
        string error = process.StandardError.ReadToEnd();
        process.WaitForExit();

        Console.WriteLine("Sortie du build :\n" + output);
        if (!string.IsNullOrEmpty(error))
        {
            Console.WriteLine("Erreurs :\n" + error);
        }
    }
}