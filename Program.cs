using System;
using System.Numerics;
using Raylib_cs;

namespace MetaBalls
{
    class Program
    {
        public const int WIDTH = 400;
        public const int HEIGHT = 400;
        const int SPACING = 1;

        const int ROWS = HEIGHT / SPACING;
        const int COLS = WIDTH / SPACING;

        const int metaScalar = 2000;

        static Blob[] blobs = new Blob[6];

        static void Main(string[] args)
        {
            Raylib.InitWindow(WIDTH, HEIGHT, "MetaBalls");
            Raylib.SetTargetFPS(60);

            for (int i = 0; i < blobs.Length; i++)
            {
                blobs[i] = new Blob();
            }

            while (!Raylib.WindowShouldClose())
            {
                foreach (Blob blob in blobs)
                {
                    blob.Update();
                }

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.RAYWHITE);

                for (int x = 0; x < COLS; x++)
                {
                    for (int y = 0; y < ROWS; y++)
                    {
                        Vector2 pixelPos = new Vector2(x * SPACING, y * SPACING);
                        double total = 0;
                        foreach(Blob blob in blobs)
                        {
                            total += blob.CalculateMetaValue(pixelPos) * metaScalar / blobs.Length;
                        }
                        //Color color = Raylib.ColorFromHSV((int)Math.Clamp(total, 0, 255), 1, 1);
                        Color color = Raylib.ColorFromHSV((int)total, 1, 1);
                        Raylib.DrawPixelV(pixelPos, color);
                        //Raylib.DrawRectangle((int)pixelPos.X, (int)pixelPos.Y, SPACING, SPACING, color);
                    }
                }

                //foreach (Blob blob in blobs)
                //{
                //    blob.Display();
                //}
                Raylib.DrawFPS(50, 50);
                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }
    }
}
