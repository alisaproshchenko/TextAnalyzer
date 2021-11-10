using System;
using System.Linq;
using Core;

/*It is necessary to create an application that accepts the path to a text file as input and performs
    splitting the text into words. All found words are formed into a dictionary that contains all occurrences of the word
    in the text and the positions of these occurrences. After processing the text, the program should display statistics
    on the words found and the frequency of their repetitions in the text, the list should be sorted in descending order. 
    After displaying general statistics, the program waits for the user to enter a word and returns
    information about all occurrences of the word in the text (line number and position)*/
namespace TextAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Enter the filename: ");
            var filename = Console.ReadLine();*/
            var path = "legend.txt";
            
            try
            {
                var lines = FileProcessor.ReadLinesFromFile(path);
                var counter = new WordsCounter(lines);
                Console.WriteLine($"Lines quantity: {lines.Count()}\n");

                var words = counter.CountFrequency()
                    .OrderByDescending(x => x.Value);

                Console.WriteLine("Words and frequencies:");
                foreach (var (key, value) in words)
                {
                    Console.WriteLine($"- {key}\t{value}");
                }

                var word = "he";
                var positions = counter.FindPositionOfWord(word);

                if (!positions.Any())
                    throw new Exception($"No matches of the \"{word}\" were found");

                Console.WriteLine($"The \"{word}\" was found {positions.Count} times:");
                foreach (var (line, position) in positions)
                {
                    Console.WriteLine($"- Line {line}, position {position}");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            

            Console.ReadKey();
        }
    }
}
