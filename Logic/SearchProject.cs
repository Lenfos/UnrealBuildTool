using System;
using System.IO;
using System.Text.Json;

namespace Logic;

public class SearchProject
{

    public static List<Projects> GetAllProjects(string path = @"c:\")
    {
        List<Projects> projects = new List<Projects>();

        string[] files = Directory.GetFiles(path, "*.uproject", SearchOption.AllDirectories);
        foreach (string iFile in files)
        {
            Projects proj = new Projects(Path.GetFileNameWithoutExtension(iFile), iFile);
            
            string jsonFile = File.ReadAllText(iFile);
            JsonDocument json = JsonDocument.Parse(jsonFile);
            JsonElement root = json.RootElement;
            if (root.TryGetProperty("EngineAssociation", out JsonElement engineAssociation))
            {
                proj.UnrealVersion = engineAssociation.GetString() ?? string.Empty;
            }
            
            projects.Add(proj);
        }
        
        return projects;
    }

    public static Projects GetProjects(string path)
    {
        Projects proj = new Projects(Path.GetFileNameWithoutExtension(path), path);
        
        string jsonFile = File.ReadAllText(path);
        JsonDocument json = JsonDocument.Parse(jsonFile);
        JsonElement root = json.RootElement;
        if (root.TryGetProperty("EngineAssociation", out JsonElement engineAssociation))
        {
            proj.UnrealVersion = engineAssociation.GetString() ?? string.Empty;
        }

        return proj;
    }

}