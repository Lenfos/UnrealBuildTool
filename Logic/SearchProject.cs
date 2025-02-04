using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Logic;

public class SearchProject
{

    [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH")]
    [SuppressMessage("ReSharper.DPA", "DPA0003: Excessive memory allocations in LOH", MessageId = "type: System.String; size: 434MB")]
    public static List<Projects> GetAllProjects(string path = @"c:\")
    {
        List<Projects> projects = new List<Projects>();
        
        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = $"/c dir \"{path}\" /s /b /a *.uproject",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        Process process = new Process { StartInfo = psi };
        
        Console.WriteLine($"Searching through directory. Warning : It can take some time to search");
        
        process.Start();

        string output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();
        
        if (string.IsNullOrEmpty(output))
        {
            Console.WriteLine("No .uproject files found.");
            return new List<Projects>();
        }
        
        string[] files = GetProjectPaths(output);
        foreach (string iFile in files)
        {
            Projects proj = new Projects(Path.GetFileNameWithoutExtension(iFile), iFile);
            
            string jsonFile = File.ReadAllText(iFile);
            JsonDocument json = JsonDocument.Parse(jsonFile);
            JsonElement root = json.RootElement;
            
            if (root.ValueKind == JsonValueKind.Number)
            {
                continue; 
            }
            
            if (root.TryGetProperty("EngineAssociation", out JsonElement engineAssociation))
            {
                proj.UnrealVersion = engineAssociation.GetString() ?? string.Empty;
            }
            
            if (root.TryGetProperty("Plugins", out JsonElement plugins))
            {
                foreach (JsonElement plugin in plugins.EnumerateArray())
                {
                    if (plugin.TryGetProperty("Name", out JsonElement pluginName))
                    {
                        proj.Plugins.Add(pluginName.GetString() ?? string.Empty);
                    }
                }
            }
            
            projects.Add(proj);
        }
        
        return SortProject(projects);
    }

    public static Projects GetProjects(string path)
    {
        Projects proj = new Projects(Path.GetFileNameWithoutExtension(path), path);
        
        string jsonFile = File.ReadAllText(path);
        JsonDocument json = JsonDocument.Parse(jsonFile);
        JsonElement root = json.RootElement;
        if (root.TryGetProperty("EngineAssociation", out JsonElement engineAssociation))
        {
            proj.UnrealVersion = engineAssociation.GetString() == "" ? "From Source" : engineAssociation.GetString() ?? "From Source";
        }

        if (root.TryGetProperty("Plugins", out JsonElement plugins))
        {
            foreach (JsonElement plugin in plugins.EnumerateArray())
            {
                if (plugin.TryGetProperty("Name", out JsonElement pluginName))
                {
                    proj.Plugins.Add(pluginName.GetString() ?? string.Empty);
                }
            }
        }

        return proj;
    }

    public static string GetProjectsName(string path)
    {
        return Path.GetFileNameWithoutExtension(path);
    }
    
    private static string[] GetProjectPaths(string output)
    {
        List<string> paths = new List<string>();
        
        string pattern = @"([A-Za-z]:\\(?:[\w\\]+)*\.uproject)";
        Regex regex = new Regex(pattern);

        MatchCollection matches = regex.Matches(output);
        foreach (Match match in matches)
        {
            paths.Add(match.Value); 
        }

        return paths.ToArray();
    }

    private static List<Projects> SortProject(List<Projects> projects)
    {
        List<Projects> resProjects = new List<Projects>();
        List<string> paths = new List<string>();

        foreach (Projects iProj in projects)
        {
            if (!paths.Contains(iProj.Path))
            {
                paths.Add(iProj.Path);
                resProjects.Add(iProj);
            }
        }
        
        return resProjects;
    }

}