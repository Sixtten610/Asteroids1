using System;
using Raylib_cs;

namespace Triangle2
{
    class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(500, 500, "Opperation Window");
            Raylib.SetTargetFPS(60);

            Triangle triangle = new Triangle();

            while (!Raylib.WindowShouldClose())
                {
                    Raylib.BeginDrawing();
                    Raylib.ClearBackground(Color.BLACK);

                    
                    triangle.Mechanics();
                    triangle.Update();
                    triangle.Draw();

                    if (triangle.Shoot() == true)
                    {
                        Line line = new Line(triangle.TriangleX(), triangle.TriangleY(), triangle.TriangleV());
                    }

                    Raylib.EndDrawing();
                }






        }
    }
}
