# Advent of Code 2024
Welcome to my repository, which contains my attempts at solving the 
puzzles of [Advent of Code 2024](https://adventofcode.com/2024/). 
This year I will try to better document my process and things that
I have learned. Good luck to everyone participating this year!

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

