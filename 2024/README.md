# Advent of Code 2024
Welcome to my repository, which contains my attempts at solving the 
puzzles of [Advent of Code 2024]. This year I will try to better document 
my process and things that I have learned. Good luck to everyone 
participating this year!

[Advent of Code 2024]: https://adventofcode.com/2024/

## New things I've learned
Anything that I learn, and anything that I forgot and now discover,
will be documented here, mostly for myself. If you are reading this
and learning something new too, great!

### Auto-copy files to publication directory
Since C# is a compiled language, and because the compiled binary is
published in a subdirectory of the project root, references to non-code
files will result in runtime exceptions when trying to read them. In
my case, I had to remember to manually configure puzzle input files 
to be copied to the same directory as the resulting binary. But no 
more. 

You can add the following to your project files and save yourself
a lot of manual work and daily frustration. First we define a 
pattern to match our puzzle input files. 

```xml
<ItemGroup>
    <PuzzleInputFiles Include="*\input.txt" />
</ItemGroup>
```

Then we tell our IDE to copy all files matching that pattern to our
publication directory.

```xml
<Target Name="CopyCustomFiles" AfterTargets="Build">
    <Copy SourceFiles="@(PuzzleInputFiles)" DestinationFolder="$(OutputPath)%(RecursiveDir)" />
</Target>
```

### LINQ Zip method

For [Day 1] I needed a way to process two sets of data simultaneously. 
Apparently that is exactly what [Zip] does!

[Day 1]: https://adventofcode.com/2024/day/1
[Zip]: https://learn.microsoft.com/en-us/dotnet/csharp/linq/standard-query-operators/projection-operations#zip

### Range operators

When working on [Day 2] I was reminded of [indices and ranges] and had some 
fun experimenting with them to get to a proper solution.

[Day 2]: https://adventofcode.com/2024/day/2
[indices and ranges]: https://learn.microsoft.com/en-us/dotnet/csharp/tutorials/ranges-indexes

### Enumerable.SequenceEqual()

For [Day 5] I started with a naive approach, which was working for 
part 1 but not part 2. I ended up having to rewrite the second part and
while I was researching I encountered [SequenceEqual()] in a solution
from [Dávid Németh]

[Day 5]: https://adventofcode.com/2024/day/5
[SequenceEqual()]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.sequenceequal
[Dávid Németh]: https://github.com/encse/adventofcode/blob/master/2024/Day05/Solution.cs

### Comparers

Also for [Day 5], brushing up on custom comparers was needed. I knew
of them (and even used them in the past for other AoC puzzles) but somehow
forgot. Also credit to [Dávid Németh]
