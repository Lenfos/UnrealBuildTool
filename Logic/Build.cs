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
        
        string command  = @$".\Engine\Build\BatchFiles\Build.bat {target} {plateform} {state} -Project=" + $"\"{projectpath}\""+
        " -progress -nohotreload -waitmutex";
        
        Console.WriteLine($"[COMMAND] : {command}");
        
        RunUBT(command, true);
    }

    private static void RunUBT(string command, bool isCommandLine)
    {
        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = $"/c {command}",
            RedirectStandardOutput = isCommandLine,
            RedirectStandardError = isCommandLine,
            UseShellExecute = !isCommandLine,
            CreateNoWindow = isCommandLine
        };

        Process process = new Process { StartInfo = psi };

        if (isCommandLine)
        {
            process.OutputDataReceived += (sender, e) => 
            {
                if (!string.IsNullOrEmpty(e.Data))
                    Console.WriteLine($"[OUT] {e.Data}");
            };

            process.ErrorDataReceived += (sender, e) => 
            {
                if (!string.IsNullOrEmpty(e.Data))
                    Console.WriteLine($"[ERR] {e.Data}");
            };
        }
        
        
        process.Start();
        if (isCommandLine)
        {
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
        }
        
        process.WaitForExit();
    }

    public static void GUI_UBT(string projectpath, string unrealBuildPath)
    {
        target = SearchProject.GetProjectsName(projectpath);
        
        string command  = @$"{unrealBuildPath}\Engine\Build\BatchFiles\Build.bat {target} {plateform} {state} -Project=" + $"\"{projectpath}\""+
                          " -progress -nohotreload -waitmutex";
        
        Console.WriteLine(command);
        RunUBT(command, false);
    }

    public static void UAT(string projectpath, string targetPath)
    {
        string command  = @$".\Engine\Build\BatchFiles\RunUAT.bat -ScriptsForProject={projectpath} " + 
                          @$"BuildCookRun -project={projectpath} -noP4 -clientconfig=Development -serverconfig=Development " + 
                          @$"-nocompileeditor -unrealexe={Path.Combine(Directory.GetCurrentDirectory(), @"Engine\Binaries\Win64\UnrealEditor-Cmd.exe")} " +
                          @$"-utf8output -platform={plateform} -build -cook -unversionedcookedcontent -stage -package" + 
                          $" -archive -archivedirectory=\"{targetPath}\"";
        
        Console.WriteLine($"[COMMAND] : {command}");
        
        RunUAT(command, true);
    }

    private static void RunUAT(string command, bool isCommandLine)
    {
        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = $"/c {command}",
            RedirectStandardOutput = isCommandLine,
            RedirectStandardError = isCommandLine,
            UseShellExecute = !isCommandLine,
            CreateNoWindow = isCommandLine
        };

        Process process = new Process { StartInfo = psi };

        if (isCommandLine)
        {
            process.OutputDataReceived += (sender, e) => 
            {
                if (!string.IsNullOrEmpty(e.Data))
                    Console.WriteLine($"[OUT] {e.Data}");
            };

            process.ErrorDataReceived += (sender, e) => 
            {
                if (!string.IsNullOrEmpty(e.Data))
                    Console.WriteLine($"[ERR] {e.Data}");
            };
        }
        
        process.Start();

        if (isCommandLine)
        {
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
        }

        process.WaitForExit();
    }

    public static void GUI_UAT(string projectpath, string targetPath, string unrealBuildPath)
    {
        string command  = @$"{unrealBuildPath}\Engine\Build\BatchFiles\RunUAT.bat -ScriptsForProject={projectpath} " + 
                          @$"BuildCookRun -project={projectpath} -noP4 -clientconfig=Development -serverconfig=Development " + 
                          @$"-nocompileeditor -unrealexe={Path.Combine(Directory.GetCurrentDirectory(), @$"{unrealBuildPath}\Engine\Binaries\Win64\UnrealEditor-Cmd.exe")} " +
                          @$"-utf8output -platform={plateform} -build -cook -unversionedcookedcontent -stage -package" + 
                          $" -archive -archivedirectory=\"{targetPath}\"";
        
        Console.WriteLine(command);
        
        RunUAT(command, false);
    }
}