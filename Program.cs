﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace TextAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Enter the filename: ");
            var filename = Console.ReadLine();*/
            var filename = "legend.txt";
            var lines = new List<Line>();

            try
            {
                if (!File.Exists(filename))
                    throw new Exception("The file does not exist");
                if (!new Regex(@"\w\.txt").IsMatch(filename))
                    throw new Exception("The file is not in txt format");

                using (var sr = new StreamReader(filename))
                {
                    string readline;
                    while ((readline = sr.ReadLine()) != null)
                    {
                        var line = new Line(readline.Split(' ', '.', ',', '?', '!'));
                        lines.Add(line);
                        
                    }
                }
                Console.WriteLine(lines.Count);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            

            Console.ReadKey();
        }
    }
}