namespace Logic;

public class Projects
{
    #region Attributes

    private string name;
    private string path;
    private string unrealVersion;

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

    #endregion

    #region Constructors

    public Projects(string name, string path, string? unrealVersion = "5.4.4")
    {
        this.Name = name;
        this.Path = path;
        this.UnrealVersion = name;
    }

    public Projects(Projects projects)
    {
        this.Name = projects.Name;
        this.Path = projects.Path;
        this.UnrealVersion = projects.UnrealVersion;
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
        return $"Name: {this.Name}, Path: {this.Path}, UnrealVersion: {this.UnrealVersion}";
    }
}