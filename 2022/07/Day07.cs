namespace Basje.AdventOfCode.Y2022.D07;

public class Day07 : ISolution
{
    private const long FS_SIZE = 70_000_000;
    private const long FS_MIN_FREE = 30_000_000;

    private readonly IFilesystemNode root = new Directory { Name = "/" };

    public Day07(string input)
    {
        var terminalOutput = input
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.Split(' '));

        var currentDirectory = new Stack<Directory>();

        foreach (var line in terminalOutput)
        {
            if (line[0] == "$" && line[1] == "cd" && line[2] == "/")
            {
                currentDirectory.Clear();
                currentDirectory.Push((Directory)root);
                continue;
            }

            if (line[0] == "$" && line[1] == "cd" && line[2] == "..")
            {
                currentDirectory.Pop();
                continue;
            }

            if (line[0] == "$" && line[1] == "cd") {
                currentDirectory.Push(currentDirectory.Peek().GetDirectory(line[2]));
                continue;
            }

            if (line[0] == "$" && line[1] == "ls") continue;

            if (line[0] == "dir")
            {
                currentDirectory.Peek().Add(new Directory { Name = line[1] });
                continue;
            }

            if (line[0].All(character => '0' <= character && character <= '9'))
            {
                currentDirectory.Peek().Add(new File { Name = line[1], Size = int.Parse(line[0]) });
                continue;
            }

            throw new Exception();
        }
    }

    public object SolvePart1()
    {
        return ((Directory)root)
            .Find(dir => dir.Size <= 100_000)
            .Sum(dir => dir.Size);
    }

    public object SolvePart2()
    {
        var currentlyFree = FS_SIZE - root.Size;
        var requiredCleanup = FS_MIN_FREE - currentlyFree;

        return ((Directory)root)
            .Find(dir => dir.Size >= requiredCleanup)
            .Min(dir => dir.Size);
    }
}

public interface IFilesystemNode
{
    public long Size { get;  }

    public string Name { get; }
}

public record Directory : IFilesystemNode
{
    private List<IFilesystemNode> contents = new();

    public long Size => contents.Select(node => node.Size).Sum();

    public required string Name { get; init; }

    public void Add(IFilesystemNode node) => contents.Add(node);

    public Directory? GetDirectory(string name) => contents.Single(entry => entry is Directory && entry.Name == name) as Directory;

    public IEnumerable<Directory> Find(Func<Directory, bool> check)
    {
        var result = new List<Directory>();
        var directories = new Stack<Directory>();

        directories.Push(this);

        while(directories.Any())
        {
            var current = directories.Pop();

            foreach (var dir in current.contents.Where(d => d is Directory).Select(d => d as Directory))
            {
                directories.Push(dir);
            }

            if (check(current))
            {
                result.Add(current);
            }
        }

        return result;        
    }
}

public record File : IFilesystemNode
{
    public required long Size { get; init; }

    public required string Name { get; init; }
}


