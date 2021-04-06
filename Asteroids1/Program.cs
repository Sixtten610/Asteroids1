using System;
using Raylib_cs;

namespace Triangle2
{
    class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(1000, 1000, "Operation Window");
            Raylib.SetTargetFPS(60);

            Triangle triangle = new Triangle(KeyboardKey.KEY_W, KeyboardKey.KEY_S, KeyboardKey.KEY_A, KeyboardKey.KEY_D);

            while (!Raylib.WindowShouldClose())
                {
                    Raylib.BeginDrawing();
                    Raylib.ClearBackground(Color.BLACK);

                    if(Raylib.IsKeyPressed(KeyboardKey.KEY_KP_ENTER))
                    {
                        Asteroid asteroid = new Asteroid();
                    }
                    Asteroid.UpdateAll();
                    Asteroid.DrawAll();

                    triangle.Mechanics();
                    triangle.Update();
                    triangle.Draw();

                    if (triangle.Shoot() == true)
                    {
                        Line2 line2 = new Line2
                        (
                            triangle.TriangleX, triangle.TriangleY, 
                            triangle.TriangleV, triangle.TriangleR
                        );
                    }
                    Line2.UpdateAll();
                    Line2.DrawAll();
                    
                    Raylib.EndDrawing();
                }






        }
    }
}
