using System.Numerics;
using System;
using Raylib_cs;

namespace Triangle2
{
    public class Triangle
    {
        // TRIANGLE #########################################################
        private Vector2[] pointTriangle = new Vector2[3];

        private int xPlanePos = 500;
        private int yPlanePos = 500;

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
        
        // KEY INPUTS ########################################################

        protected KeyboardKey[] keyInputs;

        public Triangle(KeyboardKey up, KeyboardKey down, KeyboardKey left, KeyboardKey right)
        {
            keyInputs = new KeyboardKey[4];

            keyInputs[0] = up;
            keyInputs[1] = down;
            keyInputs[2] = left;
            keyInputs[3] = right;

        }

        public void Update()
        {
            // int tes = Raylib.GetKeyPressed();

            // var yes = (KeyboardKey)87;

            //System.Console.WriteLine(yes);

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
            int t = 87;
            var yes = (KeyboardKey)t;

            KeyboardKey test = (KeyboardKey)87;

            if (Raylib.IsKeyDown(test))
            {
                yPlanePos -= planeMoveSpeed;
            }
            else if (Raylib.IsKeyDown(keyInputs[1]))
            {
                yPlanePos += planeMoveSpeed;
            }
            if (Raylib.IsKeyDown(keyInputs[2]))
            {
                xPlanePos -= planeMoveSpeed;
            }
            else if (Raylib.IsKeyDown(keyInputs[3]))
            {
                xPlanePos += planeMoveSpeed;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                rotation -= moveConstantOfDegrees;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
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
        }

        public bool Shoot()
        {

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                System.Console.WriteLine("Shoot");
                return true;
            }
            else
            {
                return false;
            }
        }

        public int TriangleX
        {
            get
            {
                return xPlanePos;
            }
        }
        public int TriangleY
        {
            get
            {
                return yPlanePos;
            }
        }
        public double TriangleV
        {
            get
            {
                return rotation;
            }
        }
        public double TriangleR
        {
            get
            {
                return TriangleRot();
            }
        }

        private double TriangleRot()
        {
            double mycalcInRadians = Math.Acos(xLine[1]);
            
            double rotation = ConvertRadiansToDegrees(mycalcInRadians);

            if (yLine[1] < 0)
            {
                return -rotation;
            }

            return rotation;
        }

        // "https://www.oreilly.com/library/view/c-cookbook/0596003390/ch01s03.html"
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
