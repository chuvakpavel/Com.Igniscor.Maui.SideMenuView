using System.Diagnostics.CodeAnalysis;

namespace SampleProject.Models;

public class NavigationButtonItem
{
    [SetsRequiredMembers]
    public NavigationButtonItem(string name, string path, string description)
    {
        Name = name;
        Path = path;
        Description = description;
    }

    public required string Name { get; init; }

    public required string Description { get; init; }

    public required string Path { get; init; }
}