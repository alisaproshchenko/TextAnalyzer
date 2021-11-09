using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalyzer
{
    class Line
    {
        public int Id { get; set; }
        private static int _startId = 1;
        public IEnumerable<string>[] Words { get; set; }

        public Line(params IEnumerable<string>[] words)
        {
            Id = _startId;
            _startId++;
            Words = words;
        }

    }
}
