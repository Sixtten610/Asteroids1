using System.Diagnostics;
using System.Collections.Generic;
using System;
using Raylib_cs;
using System.Numerics;

namespace Triangle2
{
    public class Asteroid2
    {
        static List<Asteroid2> asteroids = new List<Asteroid2>();

        Rectangle rectangle = new Rectangle();

        Vector2 centerOfRect = new Vector2(50 ,50);
        static Random generator = new Random();

        float randDegree = generator.Next(0, 360);
        // float OriginX = generator.Next(0, 1000);
        // float OriginY = generator.Next(0, 1000);

        float OriginX = 500;
        float OriginY = 500;
        
        private double x;
        private double y;
        double hypotenuse = 10;

        Vector2 circlePos;


        public Asteroid2()
        {
            // rectangle.x = OriginX;
            // rectangle.y = OriginY;

            rectangle.width = 100;
            rectangle.height = 100;

            int randomConst = generator.Next(0,4);
            switch (randomConst)
            {
                case 0:
                OriginX = generator.Next(-200, -100);
                OriginY = generator.Next(0, 1000);
                break;

                case 1:
                OriginX = generator.Next(1100, 1200);
                OriginY = generator.Next(0, 1000);
                break;
                
                case 2:
                OriginY = generator.Next(-200, -100);
                OriginX = generator.Next(0, 1000);
                break;

                case 3:
                OriginY = generator.Next(1100, 1200);
                OriginX = generator.Next(0, 1000);
                break;
            }

            asteroids.Add(this);
        }
        public static void UpdateAll()
        {
            System.Console.WriteLine(asteroids.Count);
            for (int index = asteroids.Count - 1; index > 0; index--)
            {
                asteroids[index].Update();

                if (asteroids[index].Delete() || asteroids[index].OutOfBounds(index))
                {
                    asteroids.Remove(asteroids[index]);
                }
            }
        }
        
        public static void DrawAll()
        {
            for (int index = asteroids.Count - 1; index > 0; index--)
            {
                asteroids[index].Draw();
            }
        }
        private bool OutOfBounds(int index)
        {
            if (asteroids[index].x > 1250 || asteroids[index].y > 1250 || asteroids[index].x < -250 || asteroids[index].y < -250)
            {
                System.Console.WriteLine("DEL");
                return true;
            }
            return false;
        }

        private List<Line2> lineList = Line2.GetLines;
        private bool Delete()
        {
            for (int index = lineList.Count - 1; index > 0; index--)
            {
                if (Raylib.CheckCollisionCircleRec(circlePos, 60, lineList[index].GetRect) == true)
                {
                    Line2.RemoceInstanceOfLine(index);
                    return true;
                }
            }            

            return false;
        }

        private void Update()
        {
            hypotenuse -= 1;

            x = ((Math.Cos(randDegree) * hypotenuse) + OriginX);
            y = ((Math.Sin(randDegree) * hypotenuse) + OriginY);

            rectangle.x = (float)x;
            rectangle.y = (float)y;

            circlePos = new Vector2((float)x,(float)y);
        }
        Color colo = new Color(255,0,0,128);
        private void Draw()
        {
            Raylib.DrawRectanglePro(rectangle, centerOfRect, randDegree, Color.GOLD);
            Raylib.DrawCircleV(circlePos, 60, colo);
        }




        public static List<Asteroid2> GetAsteroids
        {
            get
            {
                return asteroids;
            }
        }

        public Vector2 GetCirclePos
        {
            get
            {
                return circlePos;
            }
        }

    }
}
