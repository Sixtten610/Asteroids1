using System.Numerics;
using System;
using Raylib_cs;

namespace Triangle2
{
    public class Triangle
    {
        // TRIANGLE #########################################################
        private Vector2[] pointTriangle = new Vector2[3];

        private int xPlanePos = 250;
        private int yPlanePos = 250;

        private int planeMoveSpeed = 2; 
        private double rotation = 1.565;
        private double moveConstantOfDegrees = 0.08;

        private double[] xCircle = {0, 0};
        private double[] yCircle = {0, 0};

        private float pointTrianglesDistanceFromCenter = 40;

        // LINE #############################################################

        private Vector2[] pointLine = new Vector2[2];
        private double[] xLine = {0, 0};
        private double[] yLine = {0, 0};

        public void Update()
        {
            for (int i = 0; i < 3; i++)
            {
                pointTriangle[i].X = (xPlanePos);
                pointTriangle[i].Y = (yPlanePos);

                if (i > 0)
                {
                    pointTriangle[i].X += (pointTrianglesDistanceFromCenter * ToFloat(xCircle[i - 1]));
                    pointTriangle[i].Y += (pointTrianglesDistanceFromCenter * ToFloat(yCircle[i - 1]));
                }

                if (i < 2)
                {
                    pointLine[i].X = (xPlanePos);
                    pointLine[i].Y = (yPlanePos);
                }
                if (i == 1)
                {
                    pointLine[i].X += (pointTrianglesDistanceFromCenter * ToFloat(xLine[i]));
                    pointLine[i].Y += (pointTrianglesDistanceFromCenter * ToFloat(yLine[i]));
                }
            }
        }

        public void Draw()
        {
            Raylib.DrawTriangleLines(pointTriangle[0], pointTriangle[1], pointTriangle[2], Color.RED);

            Raylib.DrawLineV(pointLine[0], pointLine[1], Color.MAGENTA);
        }

        public void Mechanics()
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {yPlanePos -= planeMoveSpeed;}
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {yPlanePos += planeMoveSpeed;}
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {xPlanePos -= planeMoveSpeed;}
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {xPlanePos += planeMoveSpeed;}

            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT) == true)
            {
                rotation -= moveConstantOfDegrees;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT) == true)
            {
                rotation += moveConstantOfDegrees;
            }

            Math1();
        }

        public void Math1()
        {
            int invert = 1;

            for (int i = 0; i < 2; i++)
            {
                if (i == 1)
                {
                    invert = -1;
                }

                xCircle[i] = Math.Cos(rotation + invert * 170);
                yCircle[i] = Math.Sin(rotation + invert * 170); 
            }

            xLine[1] = Math.Cos(rotation);
            yLine[1] = Math.Sin(rotation);
            reRotation = Math.Cos(rotation + invert * 180);
        }
        private double reRotation;

        public bool Shoot()
        {

            if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
            {
                System.Console.WriteLine("Shoot");
                return true;
            }
            else
            {
                return false;
            }
        }
        public int TriangleX()
        {
            return xPlanePos;
        }
        public int TriangleY()
        {
            return yPlanePos;
        }
        public double TriangleV()
        {
            return rotation;
        }

        public double TriangleR()
        {
            double mycalcInRadians = Math.Acos(xLine[1]);
            
            double rotation = ConvertRadiansToDegrees(mycalcInRadians);

            if (yLine[1] < 0)
            {
                return -rotation;
            }

            return rotation;
        }

        private double ConvertRadiansToDegrees(double radians)
        {
            double degrees = (180 / Math.PI) * radians;
            
            return (degrees);
        }

        private float ToFloat(double value)
        {
            return (float)value;
        }
    }
}
