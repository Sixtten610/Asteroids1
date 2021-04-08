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

        Vector2 centerOfRect;
        static Random generator = new Random();

        float randDegree = generator.Next(0, 360);
        float OriginX;
        float OriginY;
        
        private double x;
        private double y;
        private double asteroidMoveSpeed;
        private int hp;

        Vector2 circlePos;
        Color InvisColorForHitbox = new Color(0,0,0,0);

        Color asteroidColor;


        public Asteroid2()
        {
            AsteroidSettings();
            
            SpawnLocation();

            asteroids.Add(this);
        }
        
        protected virtual void AsteroidSettings()
        {
            rectangle.width = rectangle.height = 100;

            centerOfRect = new Vector2(rectangle.width/2, rectangle.width/2);

            asteroidColor = new Color(255,0,0,255);

            asteroidMoveSpeed = 10;

            hp = 200;
        }
        private void SpawnLocation()
        {
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
        }
        public static void UpdateAll()
        {
            for (int index = asteroids.Count - 1; index > 0; index--)
            {
                // uppdatera position
                asteroids[index].Update();

                // om utanför spelarea -> tabort instans av astroid
                if (asteroids[index].OutOfBounds(index))
                {
                    asteroids.Remove(asteroids[index]);
                }
                // annars titta om kollision
                else
                {
                    asteroids[index].CollisionWithLine(index);
                }
            }
        }

        private List<Line2> lineList = Line2.GetLines;
        private void CollisionWithLine(int asteroidIndex)
        {
            for (int index = lineList.Count - 1; index > 0; index--)
            {
                // om skott krockar med astroid
                if (Raylib.CheckCollisionCircleRec(asteroids[asteroidIndex].circlePos, 60, lineList[index].GetRect))
                {
                    // - skott dmg && ta bort skott
                    asteroids[asteroidIndex].hp -= lineList[index].GetDamage; 
                    Line2.RemoceInstanceOfLine(index);

                    // om hp efter -dmg >=0 ta bort astroid också
                    if (asteroids[asteroidIndex].hp <= 0)
                    {
                        asteroids.Remove(asteroids[asteroidIndex]);
                    }
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
        private void Draw()
        {
            Raylib.DrawRectanglePro(rectangle, centerOfRect, randDegree, asteroidColor);
            Raylib.DrawCircleV(circlePos, 60, InvisColorForHitbox);
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

        private void Update()
        {
            asteroidMoveSpeed -= 1;

            x = ((Math.Cos(randDegree) * asteroidMoveSpeed) + OriginX);
            y = ((Math.Sin(randDegree) * asteroidMoveSpeed) + OriginY);

            rectangle.x = (float)x;
            rectangle.y = (float)y;

            circlePos = new Vector2((float)x,(float)y);
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
