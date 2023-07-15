using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.Geometrix.WithOcp.ShapeModel
{
    internal class Triangle : IShape
    {
        public double Side1 { get; set; }

        public double Side2 { get; set; }

        public double Side3 { get; set; }

        public double CalculateArea()
        {
            double semiPerimeter = (Side1 + Side2 + Side3) / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - Side1) * (semiPerimeter - Side2) * (semiPerimeter - Side3));

        }
    }
}
