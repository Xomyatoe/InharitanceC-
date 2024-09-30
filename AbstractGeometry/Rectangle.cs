using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AbstractGeometry
{
    class Rectangle : Shape, IHaveDiagonal
    {
        static readonly int MIN_SIDE = 20;
        static readonly int MAX_SIDE = 320;
        double width;
        double height;
        public double Width
        {
            get => width;
            set=>width=
                value<MIN_SIDE ? MIN_SIDE : 
                value>MAX_SIDE?MAX_SIDE:
                value;
        }
        public double Height
        {
            get => height;
            set=>height=
                value<MIN_SIDE ? MIN_SIDE : 
                value>MAX_SIDE?MAX_SIDE:
                value;
             //			Constructors:
        public Rectangle(double width, double height, int start_x, int start_y, int line_width, Color color)
            : base(start_x, start_y, line_width, color)
        {
            Width = width;
            Height = height;
        }
        public double GetDiagonal() => Math.Sqrt(Math.Pow(Width, 2) + Math.Pow(Height, 2));
        public override double GetArea() => Width * Height;
        public override double GetPerimeter() => (Width + Height) * 2;
        public override void Draw(PaintEventArgs e)
        {
            //Console.WriteLine("Здесь должен быть рисунок прямоугольника");
            Pen pen = new Pen(Color, LineWidth);
            e.Graphics.DrawRectangle(pen, StartX, StartY, (float)Width, (float)Height);
        }
        public void DrawDiagonal(PaintEventArgs e)
        {
            Pen pen = new Pen(Color, 1);
            e.Graphics.DrawLine(pen, StartX, StartY, StartX + (int)Width, StartY + (int)Height);
        }
        public override void Info(PaintEventArgs e)
        {
            Console.WriteLine(this.GetType() + ":");
            Console.WriteLine($"Ширина: {Width}");
            Console.WriteLine($"Высота: {Height}");
            Console.WriteLine($"Диагональ: {GetDiagonal()}");
            DrawDiagonal(e);
            base.Info(e);
        }
    }
}
