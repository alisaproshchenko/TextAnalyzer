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

        public Line(params string[] words)
        {
            Id = _startId;
            _startId++;
            Words = words;
        }
        

    }
}
