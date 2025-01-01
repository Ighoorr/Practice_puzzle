using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "D:\\Practice_puzzle\\Practice_puzzle\\Puzzle\\Puzzle\\puzzle_fragments2.txt";

        List<string> numbers = File.ReadAllLines(filePath).ToList();

        var longestResults = new List<string>();

        for (int i = 0; i < numbers.Count; i++)
        {
            var root = numbers[i];
            var visited = new HashSet<string> { root };
            var results = new List<string>();

            BuildTree(root, numbers, visited, root, results);

            var longest = results.OrderByDescending(r => r.Length).FirstOrDefault();
            if (longest != null)
            {
                longestResults.Add(longest);
                Console.WriteLine(longest);
            }
        }

        for (int i = 0; i < longestResults.Count; i++)
        {
            Console.WriteLine($"Дерево {i + 1}, найдовша послідовність: {longestResults[i]}");
        }
        var overallLongest = longestResults.OrderByDescending(r => r.Length).FirstOrDefault();
        Console.WriteLine($"Найдовша загальна послідовність: {overallLongest}");
    }

    static void BuildTree(string current, List<string> numbers, HashSet<string> visited, string sequence, List<string> results)
    {
        bool extended = false;

        foreach (var number in numbers)
        {
            if (!visited.Contains(number))
            {
                if (current[^2..] == number[..2]) 
                {
                    visited.Add(number);
                    BuildTree(number, numbers, visited, sequence + number[2..], results);
                    visited.Remove(number);
                    extended = true;
                }
            }
        }

        if (!extended)
        {
            results.Add(sequence);
        }
    }
}

