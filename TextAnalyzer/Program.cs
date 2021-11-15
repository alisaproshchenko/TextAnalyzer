using System;
using System.Linq;
using Core;

namespace TextAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var path = args[0];  //throws an IndexOutOfRangeException if it`s no argument (path to file)

                var lines = FileProcessor.ReadLinesFromFile(path);
                var counter = new WordsCounter(lines);
                Console.WriteLine($"Lines quantity: {lines.Count}\n");

                var words = counter.CountFrequency(); //frequency of words repetitions

                Console.WriteLine("Words and frequencies:");
                foreach (var (key, value) in words)
                {
                    Console.WriteLine($"- {key, -15} {value, 5}");
                }

                while (true)
                {
                    Console.WriteLine("\nEnter the word to search in the text: ");
                    var word = Console.ReadLine();

                    var positions = counter.FindPositionOfWord(word); //all occurrences of the word

                    if (!positions.Any())
                    {
                        Console.WriteLine($"No matches of the \"{word}\" were found");
                        continue;
                    }
                        

                    Console.WriteLine($"\nThe \"{word}\" was found {positions.Count} times:");
                    foreach (var (line, position) in positions)
                    {
                        Console.WriteLine($"- line {line}, position {position}");
                    }
                    Console.WriteLine();
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e is IndexOutOfRangeException
                    ? "The path to file is empty, please enter the filename next time"
                    : e.Message);
            }
        }
    }
}
