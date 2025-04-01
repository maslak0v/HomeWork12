using System;
using System.Collections.Immutable;

abstract class Part
{
    public ImmutableList<string> Poem { get; protected set; } = ImmutableList<string>.Empty;

    public abstract ImmutableList<string> AddPart(ImmutableList<string> previousPoem);
}

class Part1 : Part
{
    public override ImmutableList<string> AddPart(ImmutableList<string> previousPoem)
    {
        var newPoem = previousPoem.Add("Вот дом, который построил Джек.");
        Poem = newPoem;
        return Poem;
    }
}

class Part2 : Part
{
    public override ImmutableList<string> AddPart(ImmutableList<string> previousPoem)
    {
        var newPoem = previousPoem
            .Add("А это пшеница,")
            .Add("Которая в темном чулане хранится")
            .Add("В доме, который построил Джек.");
        Poem = newPoem;
        return Poem;
    }
}

class Part3 : Part
{
    public override ImmutableList<string> AddPart(ImmutableList<string> previousPoem)
    {
        var newPoem = previousPoem
            .Add("А это веселая птица-синица,")
            .Add("Которая часто ворует пшеницу,")
            .Add("Которая в темном чулане хранится")
            .Add("В доме, который построил Джек.");
        Poem = newPoem;
        return Poem;
    }
}

class Part4 : Part
{
    public override ImmutableList<string> AddPart(ImmutableList<string> previousPoem)
    {
        var newPoem = previousPoem
            .Add("Вот кот,")
            .Add("Который пугает и ловит синицу,")
            .Add("Которая часто ворует пшеницу,")
            .Add("Которая в темном чулане хранится")
            .Add("В доме, который построил Джек.");
        Poem = newPoem;
        return Poem;
    }
}

class Part5 : Part
{
    public override ImmutableList<string> AddPart(ImmutableList<string> previousPoem)
    {
        var newPoem = previousPoem
            .Add("Вот пес без хвоста,")
            .Add("Который за шиворот треплет кота,")
            .Add("Который пугает и ловит синицу,")
            .Add("Которая часто ворует пшеницу,")
            .Add("Которая в темном чулане хранится")
            .Add("В доме, который построил Джек.");
        Poem = newPoem;
        return Poem;
    }
}
class Part6 : Part
{
    public override ImmutableList<string> AddPart(ImmutableList<string> previousPoem)
    {
        var newPoem = previousPoem
            .Add("А это корова безрогая,")
            .Add("Лягнувшая старого пса без хвоста,")
            .Add("Который за шиворот треплет кота,")
            .Add("Который пугает и ловит синицу,")
            .Add("Которая часто ворует пшеницу,")
            .Add("Которая в темном чулане хранится")
            .Add("В доме, который построил Джек.");
        Poem = newPoem;
        return Poem;
    }
}

class Part7 : Part
{
    public override ImmutableList<string> AddPart(ImmutableList<string> previousPoem)
    {
        var newPoem = previousPoem
            .Add("А это старушка, седая и строгая,")
            .Add("Которая доит корову безрогую,")
            .Add("Лягнувшую старого пса без хвоста,")
            .Add("Который за шиворот треплет кота,")
            .Add("Который пугает и ловит синицу,")
            .Add("Которая часто ворует пшеницу,")
            .Add("Которая в темном чулане хранится")
            .Add("В доме, который построил Джек.");
        Poem = newPoem;
        return Poem;
    }
}
class Part8 : Part
{
    public override ImmutableList<string> AddPart(ImmutableList<string> previousPoem)
    {
        var newPoem = previousPoem
            .Add("А это ленивый и толстый пастух,")
            .Add("Который бранится с коровницей строгою,")
            .Add("Которая доит корову безрогую,")
            .Add("Лягнувшую старого пса без хвоста,")
            .Add("Который за шиворот треплет кота,")
            .Add("Который пугает и ловит синицу,")
            .Add("Которая часто ворует пшеницу,")
            .Add("Которая в темном чулане хранится")
            .Add("В доме, который построил Джек.");
        Poem = newPoem;
        return Poem;
    }
}
class Part9 : Part
{
    public override ImmutableList<string> AddPart(ImmutableList<string> previousPoem)
    {
        var newPoem = previousPoem
            .Add("Вот два петуха,")
            .Add("Которые будят того пастуха,")
            .Add("Который бранится с коровницей строгою,")
            .Add("Которая доит корову безрогую,")
            .Add("Лягнувшую старого пса без хвоста,")
            .Add("Который за шиворот треплет кота,")
            .Add("Который пугает и ловит синицу,")
            .Add("Которая часто ворует пшеницу,")
            .Add("Которая в темном чулане хранится")
            .Add("В доме, который построил Джек.");
        Poem = newPoem;
        return Poem;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Part1 part1 = new Part1();
        Part2 part2 = new Part2();
        Part3 part3 = new Part3();
        Part4 part4 = new Part4();
        Part5 part5 = new Part5();
        Part6 part6 = new Part6();
        Part7 part7 = new Part7();
        Part8 part8 = new Part8();
        Part9 part9 = new Part9();

        var poem1 = part1.AddPart(ImmutableList<string>.Empty);
        var poem2 = part2.AddPart(poem1);
        var poem3 = part3.AddPart(poem2);
        var poem4 = part4.AddPart(poem3);
        var poem5 = part5.AddPart(poem4);
        var poem6 = part6.AddPart(poem1);
        var poem7 = part7.AddPart(poem2);
        var poem8 = part8.AddPart(poem3);
        var poem9 = part9.AddPart(poem4);

        Console.WriteLine("Part1:");
        foreach (var line in part1.Poem) Console.WriteLine(line);

        Console.WriteLine("\nPart2:");
        foreach (var line in part2.Poem) Console.WriteLine(line);

        Console.WriteLine("\nPart3:");
        foreach (var line in part3.Poem) Console.WriteLine(line);

        Console.WriteLine("\nPart4:");
        foreach (var line in part4.Poem) Console.WriteLine(line);

        Console.WriteLine("\nPart5:");
        foreach (var line in part5.Poem) Console.WriteLine(line);

        Console.WriteLine("\nPart6:");
        foreach (var line in part6.Poem) Console.WriteLine(line);

        Console.WriteLine("\nPart7:");
        foreach (var line in part7.Poem) Console.WriteLine(line);

        Console.WriteLine("\nPart8:");
        foreach (var line in part8.Poem) Console.WriteLine(line);

        Console.WriteLine("\nPart9:");
        foreach (var line in part9.Poem) Console.WriteLine(line);



    }
}
