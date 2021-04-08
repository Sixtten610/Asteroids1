using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace Triangle2
{
    public class Line2
    {
        private static List<Line2> lines = new List<Line2>();
        Rectangle rect = new Rectangle();
        Vector2 rectCenterPointVector = new Vector2();

        private double OriginX;
        private double OriginY;
        private double x;
        private double y;
        private double v;
        private double r;
        private double hypotenuse = 1;

        private int damage = 100;

        public Line2(int xI, int yI, double vI, double rI)
        {
            OriginX = xI;
            OriginY = yI;
            v = vI;
            r = rI;
            rect.x = ToFloat(OriginX);
            rect.y = ToFloat(OriginY);

            rect.width = 7;
            rect.height = 1;

            lines.Add(this);
        }

        private void Update()
        {
            hypotenuse -= 15;

            x = ((Math.Cos(v) * hypotenuse) + OriginX);
            y = ((Math.Sin(v) * hypotenuse) + OriginY);

            rect.x = ToFloat(x);
            rect.y = ToFloat(y);  
        }
        private void Draw()
        {
            Raylib.DrawRectanglePro(rect, rectCenterPointVector, ToFloat(r), Color.ORANGE);

            //Raylib.DrawRectangle(ToInt(OriginX), ToInt(OriginY), 10, 10, Color.GREEN);
        }

        private bool Delete()
        {
            if (x > 1000 || y > 1000 || x < 0 || y < 0)
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

        public static List<Line2> GetLines
        {
            get
            {
                return lines;
            }
        }
        public Rectangle GetRect
        {
            get
            {
                return rect;
            }
        }
        public int GetDamage
        {
            get
            {
                return damage;
            }
        }

        public static void RemoceInstanceOfLine(int index)
        {
            lines.Remove(lines[index]);
        }

        static float ToFloat(double value)
        {
            return (float)value;
        }
    }
}
