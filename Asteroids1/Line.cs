using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace Triangle2
{
    public class Line
    {
        static List<Line> lines = new List<Line>();
        Rectangle rectangle = new Rectangle();
        Vector2 originLine = new Vector2();

        private double x;
        private double y;
        private double v;
        private double hypotenuse = 1;

        private float rectRotation = 0;

        public Line(int xI, int yI, double vI)
        {
            x = xI;
            y = yI;
            v = vI;
            originLine.X = ToFloat(x);
            originLine.Y = ToFloat(y);

            rectangle.width = 10;
            rectangle.height = 50;
            rectRotation = ToFloat(v);

            lines.Add(this);
        }

        private void Update()
        {
            hypotenuse =+ 0.05;

            y += Math.Sin(v) * hypotenuse;
            x += Math.Cos(v) * hypotenuse;
        }
        private void Draw()
        {
            Raylib.DrawRectanglePro(rectangle, originLine, rectRotation, Color.ORANGE);
        }

        private bool Delete()
        {
            if (x > 600 || y > 600 || x < 600 || y < 600)
            {
                return true;
            }
            return false;
        }
        public static void UpdateAll()
        {
            for (int index = lines.Count - 1; index > 0; index--)
            {
                lines[index].Update();
                if (lines[index].Delete() == true)
                {
                    lines.Remove(lines[index]);
                }
            }
        }
        public static void DrawAll()
        {
            for (int index = lines.Count - 1; index > 0; index--)
            {
                lines[index].Draw();
            }
        }

        public static void NumberOfProjectiles()
        {
            System.Console.WriteLine(lines.Count);
        }
        public void Values()
        {
            System.Console.WriteLine("x " + x);
            System.Console.WriteLine("y " + y);
            System.Console.WriteLine("v " + v);

        }

        static float ToFloat(double value)
        {
            return (float)value;
        }
    }
}
