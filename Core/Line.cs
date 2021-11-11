using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Line
    {
        public int Id { get; set; }
        private static int _startId = 1;
        public string[] Words { get; set; }
        public string FullLine { get; set; }

        public Line(string line, params string[] words)
        {
            Id = _startId;
            _startId++;
            FullLine = line;
            Words = words;
        }
        

    }
}
