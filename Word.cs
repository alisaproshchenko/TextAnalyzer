using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalyzer
{
    class Word
    {
        public string Name { get; set; }
        public int Frequency { get; set; }

        public Word(string name)
        {
            Name = name;
            Frequency = 1;
        }
    }
}
