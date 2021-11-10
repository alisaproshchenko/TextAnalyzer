using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Core
{
    public class WordsCounter
    {
        public IEnumerable<Line> Lines { get; set; }

        public WordsCounter(IEnumerable<Line> lines)
        {
            Lines = lines;
        }
        public IDictionary<string, int> CountFrequency()
        {
            var result = new Dictionary<string, int>();
            foreach (var line in Lines)
            {
                foreach (var word in line.Words)
                {
                    if (result.ContainsKey(word.ToLower()))
                        result[word.ToLower()] += 1;
                    else
                    {
                        result[word.ToLower()] = 1;
                    }
                }
            }

            return result;
        }

        public IDictionary<int, int> FindPositionOfWord(string word)
        {
            var result = new Dictionary<int, int>();
            var lowerWord = word.ToLower();
            foreach (var line in Lines)
            {
                for (var j = 0; j < line.Words.Count(); j++)
                {
                    if(line.Words[j] == lowerWord)
                        result.Add(line.Id, j + 1);
                }
            }
            return result;
        }
    }
}
