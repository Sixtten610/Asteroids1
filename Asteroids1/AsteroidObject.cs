using System.Collections.Generic;
using System;
using Raylib_cs;
using System.Numerics;

namespace Asteroids1
{
    public class AsteroidObject
    {
        static List<AsteroidObject> asteroids = new List<AsteroidObject>();

        Rectangle rectangle = new Rectangle();
        Vector2 centerOfRect = new Vector2(0 ,0);
        static Random generator = new Random();


        double randDegree = generator.Next(0, 360);
        double OriginX = generator.Next(-200, 0);
        double OriginY = generator.Next(-200, 1200);
        
        private double x;
        private double y;
        double hypotenuse = 1;
        

        public AsteroidObject()
        {
            
        }

        private void Update()
        {
            hypotenuse -= 5;

            x = ((Math.Cos(randDegree) * hypotenuse) + OriginX);
            y = ((Math.Sin(randDegree) * hypotenuse) + OriginY);

            rectangle.x = (float)x;
            rectangle.y = (float)y;
        }
    }
}
