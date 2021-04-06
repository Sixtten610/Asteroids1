using System.Collections.Generic;
using System;
using Raylib_cs;
using System.Numerics;

namespace Triangle2
{
    public class Asteroid
    {
        static List<Asteroid> asteroids = new List<Asteroid>();

        Rectangle rectangle = new Rectangle();

        Vector2 centerOfRect = new Vector2(0 ,0);
        static Random generator = new Random();


        float randDegree = generator.Next(0, 360);
        // float OriginX = generator.Next(0, 1000);
        // float OriginY = generator.Next(0, 1000);

        float OriginX = 500;
        float OriginY = 500;
        
        private double x;
        private double y;
        double hypotenuse = 1;
        

        public Asteroid()
        {
            rectangle.x = OriginX;
            rectangle.y = OriginY;

            rectangle.width = 100;
            rectangle.height = 100;

            asteroids.Add(this);
        }
        public static void UpdateAll()
        {
            for (int index = asteroids.Count - 1; index > 0; index--)
            {
                asteroids[index].Update();
                if (asteroids[index].Delete() == true)
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

        private List<Line2> lineList = Line2.lines;
        private bool Delete()
        {
            for (int index = lineList.Count - 1; index > 0; index--)
            {
                if (Raylib.CheckCollisionRecs(lineList[index].rect, rectangle) == true)
                {
                    return true;
                }
            }            

            return false;
        }

        private void Update()
        {
            hypotenuse -= 0;

            x = ((Math.Cos(randDegree) * hypotenuse) + OriginX);
            y = ((Math.Sin(randDegree) * hypotenuse) + OriginY);

            rectangle.x = (float)x;
            rectangle.y = (float)y;
        }

        private void Draw()
        {
            Raylib.DrawRectanglePro(rectangle, centerOfRect, 0, Color.GREEN);
            Raylib.DrawRectanglePro(rectangle, centerOfRect, randDegree, Color.GOLD);
            
        }
    }
}
