using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace Triangle2
{
    public class Line2
    {
        static List<Line2> lines = new List<Line2>();
        Rectangle rectangle = new Rectangle();
        Vector2 originLine = new Vector2();


        private double OriginX;
        private double OriginY;
        private double x;
        private double y;
        private double v;
        private double hypotenuse = 1;

        private float rectRotation = 0;

        public Line2(int xI, int yI, double vI)
        {
            OriginX = xI;
            OriginY = yI;
            v = vI;
            originLine.X = ToFloat(OriginX);
            originLine.Y = ToFloat(OriginY);

            rectangle.width = 100;
            rectangle.height = 100;
            rectRotation = ToFloat(v);

            lines.Add(this);
        }

        private void Update()
        {
            hypotenuse =+ 0.05;

            x = (Math.Cos(v) * hypotenuse) + OriginX;
            y = (Math.Sin(v) * hypotenuse) + OriginY;

            originLine.X = ToFloat(x);
            originLine.Y = ToFloat(y);

            System.Console.WriteLine(originLine.X + " | " + originLine.Y);
        }
        private void Draw()
        {
            Raylib.DrawRectanglePro(rectangle, originLine, rectRotation, Color.ORANGE);

            Raylib.DrawRectangle(ToInt(x), ToInt(y), 50, 50, Color.ORANGE);
        }

        // private bool Delete()
        // {
        //     if (x > 600 || y > 600 || x < 600 || y < 600)
        //     {
        //         return true;
        //     }
        //     return false;
        // }
        public static void UpdateAll()
        {
            for (int index = lines.Count - 1; index > 0; index--)
            {
                lines[index].Update();
                // if (lines[index].Delete() == true)
                // {
                //     lines.Remove(lines[index]);
                // }
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
        static int ToInt(double value)
        {
            return (int)value;
        }
    }
}
