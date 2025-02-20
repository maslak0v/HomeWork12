using System;
using System.Collections.Generic;

// Базовый класс для частей стихотворения
abstract class Part
{
    public List<string> Poem { get; protected set; } = new List<string>();

    public abstract List<string> AddPart(List<string> previousPoem);
}

// Пример реализации части 1
class Part1 : Part
{
    public override List<string> AddPart(List<string> previousPoem)
    {
        var newPoem = new List<string>(previousPoem);
        newPoem.Add("Вот дом, который построил Джек.");
        Poem = newPoem;
        return Poem;
    }
}

// Пример реализации части 2
class Part2 : Part
{
    public override List<string> AddPart(List<string> previousPoem)
    {
        var newPoem = new List<string>(previousPoem);
        newPoem.Add("А это пшеница,");
        newPoem.Add("Которая в темном чулане хранится");
        newPoem.Add("В доме, который построил Джек.");
        Poem = newPoem;
        return Poem;
    }
}

// Основная программа
class Program
{
    static void Main(string[] args)
    {
        Part1 part1 = new Part1();
        Part2 part2 = new Part2();
        // Добавьте остальные части аналогично...

        // Последовательное добавление частей
        var poem1 = part1.AddPart(new List<string>());
        var poem2 = part2.AddPart(poem1);

        // Вывод результатов
        Console.WriteLine("Part1:");
        foreach (var line in part1.Poem) Console.WriteLine(line);

        Console.WriteLine("\nPart2:");
        foreach (var line in part2.Poem) Console.WriteLine(line);
    }
}