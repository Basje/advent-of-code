namespace Basje.AdventOfCode.Y2022.D07;

public class Day07 : ISolution
{
    private readonly Directory root = new Directory { Name = "/" };

    public Day07(string input)
    {

        var terminalOutput = input
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.Split(' '))
            .Select(line => (line[0], line[1], line.Length > 2 ? line[2] : null));

        var currentDirectory = new Stack<Directory>();

        foreach (var line in terminalOutput)
        {
            switch(line)
            {
                case ("$", "cd", "/"):
                    currentDirectory.Push(root);
                    break;
                case ("$", "cd", ".."):
                    currentDirectory.Pop();
                    break;
                case ("$", "cd", _):
                    currentDirectory.Push(currentDirectory.Peek().GetDirectory(line.Item3)!);
                    break;
                case ("$", "ls", _):
                    break;
                case ("dir", _, _):
                    currentDirectory.Peek().Add(new Directory { Name = line.Item2 });
                    break;
                case (_, _, _) when line.Item1.All(character => '0' <= character && character <= '9'):
                    currentDirectory.Peek().Add(new File { Name = line.Item2, Size = int.Parse(line.Item1) });
                    break;
                case (_, _, _):
                    throw new Exception();
            };
        }
    }

    public object SolvePart1()
    {
        return root
            .Find(dir => dir.Size <= 100_000)
            .Sum(dir => dir.Size);
    }

    public object SolvePart2()
    {
        const long FS_SIZE = 70_000_000;
        const long FS_MIN_FREE = 30_000_000;

        var currentlyFree = FS_SIZE - root.Size;
        var requiredCleanup = FS_MIN_FREE - currentlyFree;

        return root
            .Find(dir => dir.Size >= requiredCleanup)
            .Min(dir => dir.Size);
    }
}

// Common interface so that I can put all nodes in the same collection
public interface IFilesystemNode
{
    public long Size { get;  }

    public string Name { get; }
}

// Files are dumb data records
public record File : IFilesystemNode
{
    public required long Size { get; init; }

    public required string Name { get; init; }
}

// Directories have some added logic on top of the data
public record Directory : IFilesystemNode
{
    private readonly List<IFilesystemNode> contents = new();

    public required string Name { get; init; }
    public long Size => contents.Select(node => node.Size).Sum();


    public void Add(IFilesystemNode node) => contents.Add(node);
    public Directory? GetDirectory(string name) => contents.Single(entry => entry is Directory && entry.Name == name) as Directory;

    public IEnumerable<Directory> Find(Func<Directory, bool> check)
    {
        var result = new List<Directory>();
        var directories = new Stack<Directory>();

        // Start with current node
        directories.Push(this);
        // As long as we have nodes to process
        while (directories.Any())
        {
            // Get a node
            var current = directories.Pop();
            // Get all directories of this node for later processing
            foreach (var dir in current.contents.Where(d => d is Directory).Select(d => d as Directory))
            {
                directories.Push(dir!);
            }
            // Check if we are looking for current node
            if (check(current))
            {
                result.Add(current);
            }
        }
        return result;
    }
}
