using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace Core
{
    public class WordsCounter
    {
        public IEnumerable<Line> Lines { get; set; }

        public WordsCounter(IEnumerable<Line> lines)
        {
            Lines = lines;
        }
        public IOrderedEnumerable<KeyValuePair<string, int>> CountFrequency() //frequency of words repetitions
        {
            var result = new Dictionary<string, int>();
            foreach (var line in Lines)
            {
                foreach (var word in line.Words)
                {
                    if (result.ContainsKey(word.ToLower()))
                        result[word.ToLower()] += 1;
                    else
                        result[word.ToLower()] = 1;
                }
            }

            return result.OrderByDescending(x => x.Value);
        }

        public IList<(int, int)> FindPositionOfWord(string word) //all occurrences of the word
        {
            var regex = new Regex(PatternBuilder(word));
            return (from line in Lines 
                let matches = regex.Matches(line.FullLine) 
                where matches.Any() 
                from Match match in matches 
                select (line.Id, match.Index + 1)).ToList();
        }

        private string PatternBuilder(string word)
        {
            var sb = new StringBuilder(word);
            sb.Remove(0, 1);
            sb.Insert(0, $"[{word.ToLower()[0]}{word.ToUpper()[0]}]");
            return "\\b" + sb + "\\b";
        }
    }
}
