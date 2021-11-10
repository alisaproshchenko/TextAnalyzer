using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Core
{
    public class FileProcessor
    {
        public static IEnumerable<Line> ReadLinesFromFile(string path)
        {
            if (!File.Exists(path))
                throw new Exception("The file does not exist");
            if (!new Regex(@"\w\.txt").IsMatch(path))
                throw new Exception("The file is not in txt format");

            var lines = new List<Line>();
            using (var sr = new StreamReader(path))
            {
                string readline;
                while ((readline = sr.ReadLine()) != null)
                {
                    var line = new Line(readline.Split(new[] { ' ', '.', ',', '?', '!' }, StringSplitOptions.RemoveEmptyEntries));
                    lines.Add(line);

                }
            }

            return lines;
        }
        
    }
}
