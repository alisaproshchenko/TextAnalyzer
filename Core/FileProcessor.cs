using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Core
{
    public class FileProcessor
    {
        public static IList<Line> ReadLinesFromFile(string path)
        {
            if (!File.Exists(path))
                throw new Exception("The file does not exist or check if filename is written correctly");

            if (!new Regex(@"\w\.txt").IsMatch(path))
                throw new Exception("The file is not in txt format");

            var lines = new List<Line>();

            using var sr = new StreamReader(path);
            string fullLine;
            while ((fullLine = sr.ReadLine()) != null)
            {
                var line = new Line(fullLine, 
                    fullLine.Split(new[] { ' ', '.', ',', '?', '!', '(', ')', '[', ']' }, StringSplitOptions.RemoveEmptyEntries));
                lines.Add(line);

            }

            return lines;
        }
        
    }
}
