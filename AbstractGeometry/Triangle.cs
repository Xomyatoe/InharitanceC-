using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractGeometry
{
    public class Triangle : Shape, IHaveHeight
    {
        public double Height { get; set; }
    }

    public class RightTriangle : Triangle
    {
        private double b_ase;
        private double height;

        public RightTriangle(double Base, double Height)
        {
            b_ase = Base;
            height = Height;
        }

        public override double GetArea() => 0.5 * b_ase * height;
        public override double GetPerimeter() => b_ase + height + Math.Sqrt(b_ase * b_ase + height * height);
    }

    public class EquilateralTriangle : Triangle
    {
        private double SideLength;

        public EquilateralTriangle(double sideLength)
        {
            SideLength = sideLength;
        }

        public override double GetArea() => Math.Sqrt(3) / 4 * SideLength * SideLength;
        public override double GetPerimeter() => 3 * SideLength;
    }
