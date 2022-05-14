﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RoundProject.Entities
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point() { X = 0; Y = 0; }
        public Point(int x, int y) { X = x; Y = y; }
        public Point(int T) { X = T; Y = T; }
    }
}
