using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Core
{
    public class FileProcessor
    {
        private static readonly int CharMin = Convert.ToInt32(char.MinValue);
        private static readonly int CharMax = Convert.ToInt32(char.MaxValue);
        public static IList<Line> ReadLinesFromFile(string path)
        {
            if (!File.Exists(path))
                throw new Exception("The file does not exist or check if filename is written correctly");

            if (!new Regex(@"\w\.txt").IsMatch(path))
                throw new Exception("The file is not in txt format");

            var lines = new List<Line>();

            using var sr = new StreamReader(path);
            string fullLine;

            var separators = Enumerable.Range(CharMin, CharMax - CharMin + 1)
                .Select(c => (char)c)
                .Where(x => char.IsSeparator(x) || char.IsPunctuation(x))
                .ToArray();

            while ((fullLine = sr.ReadLine()) != null)
            {
                var line = new Line(fullLine,
                    fullLine.Split(separators, StringSplitOptions.RemoveEmptyEntries));
                lines.Add(line);

            }

            return lines;
        }
        
        
    }
}
