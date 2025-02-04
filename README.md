
# Unreal Engine Build Tool

This program lets you manage Unreal Engine projects by offering a number of functions via the command line or the graphical interface. You can display information about a project, compile it, package it, or list all the Unreal projects on your disk.


## Known issues

The `all-projects` command:
The command seems not to find the **.uproject** from source

## Command line use

### Available options

The program accepts several command line options. Here are the available options:

#### 1. `show-infos`
Displays details of a project from its `.uproject` file.

**Exemple of use**

```bash
[Toolconsole.exe path] show-infos C:/path/to/your/project.uproject
```

#### 2. `build`
Compiles the `.uproject` project with UnrealBuildTool (UBT).

**Example of use:**

```bash
[Toolconsole.exe path] C:/path/to/your/project.uproject build
```

#### 3. `package`
Package the project with Unreal Automation Tool (UAT). It requires a destination path as the third argument.

**Example of use:**

```bash
[Toolconsole.exe path] C:/path/to/your/project.uproject package C:/path/to/folder/destination
```

#### 4. `all-projects`
Lists all Unreal Engine projects found on disk. This mode accepts an optional argument to specify the directory from which to start the search (by default, the search starts at `C:/`).

**Example of use:**

```bash
[Toolconsole.exe path] all-projects [C:/path/to/folder: Optional]
```

### Argument `-h`

If you're not sure what to do, you can pass the `-h` argument to display help.

**Example of use:**

```bash
[exe path] -h
```


#### Example with a specific search path :

```bash
[chemin du exe] all-projects D:/MyUnrealProject
```

### About the program

The program starts by checking whether an argument has been passed. If no argument has been given, it displays help.

#### Detailed operation :

1. If the first argument is `-h`, help is displayed.
2. If the first argument is `all-projects`, it searches the disk for Unreal projects from the specified directory (or `C:/` by default).
3. If the second argument is `show-infos`, it retrieves and displays information about a project.
4. If the second argument is `build`, it compiles the project via UnrealBuildTool.
5. If the second argument is `package`, it starts the project packaging process via Unreal Automation Tool, requiring a third argument for the destination.




