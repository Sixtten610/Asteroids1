using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace Triangle2
{
    public class Line2
    {
        static List<Line2> lines = new List<Line2>();
        Rectangle rect = new Rectangle();
        Vector2 rectCenterPointVector = new Vector2();


        private double OriginX;
        private double OriginY;
        private double x;
        private double y;
        private double v;
        private double r;
        private double hypotenuse = 1;

        public Line2(int xI, int yI, double vI, double rI)
        {
            OriginX = xI;
            OriginY = yI;
            v = vI;
            r = rI;
            rect.x = ToFloat(OriginX);
            rect.y = ToFloat(OriginY);

            rect.width = 70;
            rect.height = 10;

            
            // rectangle.x = 250;
            // rectangle.y = 250;

            // rectRotation = Math.Sin(v);            


            //System.Console.WriteLine(rectRotation);
            //System.Console.WriteLine(OriginX + " | " + OriginY);

            lines.Add(this);
        }

        private void Update()
        {
            hypotenuse -= 1;

            x = ((Math.Cos(v) * hypotenuse) + OriginX);
            y = ((Math.Sin(v) * hypotenuse) + OriginY);


            rect.x = ToFloat(x);
            rect.y = ToFloat(y);


            //System.Console.WriteLine(originLine.X + " | " + originLine.Y);
            
        }
        private void Draw()
        {
            Raylib.DrawRectanglePro(rect, rectCenterPointVector, ToFloat(r), Color.ORANGE);

            //Raylib.DrawRectangle(ToInt(OriginX), ToInt(OriginY), 10, 10, Color.GREEN);
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
