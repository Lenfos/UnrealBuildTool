namespace Logic;

public class Projects
{
    #region Attributes

    private string name;
    private string path;
    private string unrealVersion;
    private List<string> plugins;

    #endregion

    #region Properties

    public string Name
    {
        get => name;
        set => name = value;
    }

    public string Path
    {
        get => path;
        set => path = value;
    }

    public string UnrealVersion
    {
        get => unrealVersion;
        set => unrealVersion = value;
    }

    public List<string> Plugins
    {
        get => plugins;
        set => plugins = value;
    }
    
    #endregion

    #region Constructors

    public Projects(string name, string path, string? unrealVersion = "5.4.4")
    {
        this.Name = name;
        this.Path = path;
        this.UnrealVersion = name;
        this.Plugins = new List<string>();
    }

    public Projects(Projects projects)
    {
        this.Name = projects.Name;
        this.Path = projects.Path;
        this.UnrealVersion = projects.UnrealVersion;
        this.Plugins = projects.Plugins;
    }

    #endregion

    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != typeof(Projects) )
        {
            return false;
        }
        
        Projects res = (Projects)obj;
        
        return (res.Name == this.Name && res.Path == this.Path && res.UnrealVersion == this.UnrealVersion);
    }

    public override string ToString()
    {
        string res = $"\nName: {this.Name}, \nPath: {this.Path}, \nUnrealVersion: {this.UnrealVersion}, \nPlugins : [\n";

        foreach (string plugin in this.Plugins)
        {
            res += $"   {plugin}, \n";
        }

        res += "]";
        
        return res;
    }
}