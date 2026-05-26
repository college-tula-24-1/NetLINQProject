using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLINQProject
{
    class Shape
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    class Rectangle : Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }

    class Circle : Shape
    {
        public int Radius { get; set; }
    }
}
